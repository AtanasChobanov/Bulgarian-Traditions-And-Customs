using BulgarianTraditionsAndCustoms.Data;
using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models;
using BulgarianTraditionsAndCustoms.Models.Participants;
using BulgarianTraditionsAndCustoms.Models.Traditions;
using BulgarianTraditionsAndCustoms.ViewModels;
using BulgarianTraditionsAndCustoms.ViewModels.Participants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ParticipantsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(ParticipantFilterQuery query)
        {
            var participantsQuery = _context.Participants.Include(p => p.TraditionParticipants).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SearchString))
            {
                participantsQuery = participantsQuery.Where(p => p.Name.Contains(query.SearchString));
            }

            participantsQuery = query.SortOrder switch
            {
                "name_desc" => participantsQuery.OrderByDescending(p => p.Name),
                _ => participantsQuery.OrderBy(p => p.Name)
            };

            var paginatedParticipants = await PaginatedList<Participant>.CreateAsync(participantsQuery, query.PageNumber, query.PageSize);

            var viewModel = new ParticipantIndexViewModel
            {
                Participants = paginatedParticipants,
                FilterQuery = query
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new ParticipantFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ParticipantFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Upload image if present
                if (viewModel.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "participants");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(fileStream);
                    }
                    viewModel.Participant.ImagePath = "/images/participants/" + uniqueFileName;
                }
         
                _context.Participants.Add(viewModel.Participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var participant = _context.Participants
                .Include(p => p.TraditionParticipants)
                    .ThenInclude(tp => tp.Tradition)
                .FirstOrDefault(p => p.Id == id);

            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var participant = await _context.Participants
                .Include(p => p.TraditionParticipants)
                    .ThenInclude(tp => tp.Tradition)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (participant == null)
            {
                return NotFound();
            }

            var related = participant.TraditionParticipants?.Select(tp => tp.Tradition).ToList() ?? new List<Tradition>();
            var viewModel = new ParticipantFormViewModel
            {
                Participant = participant,
                Traditions = related,
                SelectedTraditionIds = related.Select(t => t.Id).ToList(),
                ParticipantRoles = participant.TraditionParticipants.ToDictionary(tp => tp.TraditionId, tp => tp.ParticipantRole ?? string.Empty)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, ParticipantFormViewModel viewModel)
        {
            if (id != viewModel.Participant.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var participant = await _context.Participants
                        .Include(p => p.TraditionParticipants)
                        .FirstOrDefaultAsync(p => p.Id == viewModel.Participant.Id);

                    if (participant == null)
                    {
                        return NotFound();
                    }

                    _context.Entry(participant).CurrentValues.SetValues(viewModel.Participant);

                    participant.TraditionParticipants.Clear();
                    foreach (var traditionId in viewModel.SelectedTraditionIds)
                    {
                        participant.TraditionParticipants.Add(new TraditionParticipant
                        {
                            TraditionId = traditionId,
                            ParticipantRole = viewModel.ParticipantRoles[traditionId]
                        });
                    }

                    // Delete image file on server if there is any
                    if (viewModel.RemoveImage && !string.IsNullOrEmpty(participant.ImagePath))
                    {
                        string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, participant.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                        participant.ImagePath = null;
                    }
                    // Update image if there is a new upload
                    else if (viewModel.ImageFile != null)
                    {
                        // Delete old file first
                        if (!string.IsNullOrEmpty(participant.ImagePath))
                        {
                            string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, participant.ImagePath.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Upload new image file - same as Create Action
                        string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "participants");
                        Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await viewModel.ImageFile.CopyToAsync(fileStream);
                        }
                        participant.ImagePath = "/images/participants/" + uniqueFileName;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Participants.Any(p => p.Id == viewModel.Participant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id });
            }

            viewModel.Traditions = _context.Participants
                .Include(p => p.TraditionParticipants)
                .Where(p => p.Id == viewModel.Participant.Id)
                .SelectMany(p => p.TraditionParticipants.Select(tp => tp.Tradition))
                .ToList();
            // populate roles dictionary for the view
            var roles = _context.TraditionsParticipants
                .Where(tp => tp.ParticipantId == viewModel.Participant.Id)
                .ToDictionary(tp => tp.TraditionId, tp => tp.ParticipantRole ?? string.Empty);
            viewModel.ParticipantRoles = roles;
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var participant = _context.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }

            // Check if there is image path to delete
            if (!string.IsNullOrEmpty(participant.ImagePath))
            {
                // Find absolute path to file
                string imagePath = Path.Combine(_hostEnvironment.WebRootPath, participant.ImagePath.TrimStart('/'));

                // Delete the file if it exists on the server
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            var hasTraditions = _context.TraditionsParticipants.Any(tp => tp.ParticipantId == id);
            if (hasTraditions)
            {
                TempData["ErrorMessage"] = "Не може да изтриете този участник, защото има свързани с него традиции!";
                return RedirectToAction(nameof(Index));
            }

            _context.Participants.Remove(participant);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Участникът беше успешно изтрит.";
            return RedirectToAction(nameof(Index));
        }
    }
}