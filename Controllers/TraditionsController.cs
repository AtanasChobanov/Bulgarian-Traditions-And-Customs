using BulgarianTraditionsAndCustoms.Data;
using BulgarianTraditionsAndCustoms.Enums;
using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models.Holidays;
using BulgarianTraditionsAndCustoms.Models.Participants;
using BulgarianTraditionsAndCustoms.Models.Traditions;
using BulgarianTraditionsAndCustoms.ViewModels;
using BulgarianTraditionsAndCustoms.ViewModels.Traditions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Controllers
{
    public class TraditionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TraditionsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(TraditionFilterQuery query)
        {
            // ===== 1. Данни за dropdown-ите =====

            ViewBag.Regions = Enum.GetValues(typeof(Region)).Cast<Region>();
            ViewBag.TraditionTypes = Enum.GetValues(typeof(TraditionType)).Cast<TraditionType>();
            ViewBag.Holidays = new SelectList(_context.Holidays, "Id", "Name");
            ViewBag.Participants = new SelectList(_context.Participants, "Id", "Name");

            // ===== 2. Основна заявка =====

            var traditionsQuery = _context.Traditions
                .Include(t => t.Holidays)
                .Include(t => t.TraditionParticipants)
                    .ThenInclude(tp => tp.Participant)
                .AsQueryable();

            // ===== 3. Търсене =====

            if (!string.IsNullOrWhiteSpace(query.SearchString))
            {
                traditionsQuery = traditionsQuery
                    .Where(t => t.Name.Contains(query.SearchString));
            }

            // ===== 4. Филтри =====

            if (query.TraditionTypes?.Any() == true) 
            { 
                traditionsQuery = traditionsQuery.Where(t => query.TraditionTypes.Contains(t.TraditionType)); 
            }
            if (query.Regions?.Any() == true) 
            { 
                traditionsQuery = traditionsQuery.Where(t => query.Regions.Contains(t.Region)); 
            }
            if (query.HolidayIds?.Any() == true) 
            { 
                traditionsQuery = traditionsQuery.Where(t => t.Holidays.Any(h => query.HolidayIds.Contains(h.Id))); 
            }
            if (query.ParticipantIds?.Any() == true) 
            { 
                traditionsQuery = traditionsQuery.Where(t => t.TraditionParticipants.Any(tp => query.ParticipantIds.Contains(tp.ParticipantId))); 
            }

            // ===== 5. Филтриране по период =====

            if (query.DateFrom.HasValue && !query.DateTo.HasValue)
            {
                traditionsQuery = traditionsQuery
                    .Where(t => t.CelebrationDate.Date == query.DateFrom.Value.Date);
            }
            else if (!query.DateFrom.HasValue && query.DateTo.HasValue)
            {
                traditionsQuery = traditionsQuery
                    .Where(t => t.CelebrationDate.Date == query.DateTo.Value.Date);
            }
            else if (query.DateFrom.HasValue && query.DateTo.HasValue)
            {
                traditionsQuery = traditionsQuery
                    .Where(t => t.CelebrationDate.Date >= query.DateFrom.Value.Date &&
                                t.CelebrationDate.Date <= query.DateTo.Value.Date);
            }

            // ===== 6. Сортиране =====

            traditionsQuery = query.SortOrder switch
            {
                "name_desc" => traditionsQuery.OrderByDescending(t => t.Name),

                "upcoming" => traditionsQuery.OrderBy(t => t.CelebrationDate),

                "region_asc" => traditionsQuery.OrderBy(t => t.Region),
                "region_desc" => traditionsQuery.OrderByDescending(t => t.Region),

                _ => traditionsQuery.OrderBy(t => t.Name)
            };

            // ===== 7. Странициране =====

            var paginatedTraditions = await PaginatedList<Tradition>.CreateAsync(traditionsQuery, query.PageNumber, query.PageSize);

            // Create ViewModel
            var viewModel = new TraditionIndexViewModel
            {
                Traditions = paginatedTraditions,
                FilterQuery = query
            };

            return View(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new TraditionFormViewModel();
            PopulateDropDowns(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TraditionFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Upload image if there is any
                if (viewModel.ImageFile != null)
                {
                    // Define and create folder for images
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "traditions");
                    Directory.CreateDirectory(uploadsFolder);

                    // Generate unique name for image file
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save the file
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.ImageFile.CopyToAsync(fileStream);
                    }
                    viewModel.Tradition.ImagePath = "/images/traditions/" + uniqueFileName;
                }

                // Set up related Holidays
                viewModel.Tradition.Holidays = new List<Holiday>();
                foreach (var holidayId in viewModel.SelectedHolidayIds)
                {
                    var holiday = _context.Holidays.Find(holidayId);
                    viewModel.Tradition.Holidays.Add(holiday);
                }

                // Set up related Participants
                viewModel.Tradition.TraditionParticipants = new List<TraditionParticipant>();
                foreach (var participantId in viewModel.SelectedParticipantIds)
                {
                    viewModel.Tradition.TraditionParticipants.Add(new TraditionParticipant { ParticipantId = participantId, ParticipantRole = viewModel.ParticipantRoles[participantId] });
                }

                // Save to DB
                _context.Traditions.Add(viewModel.Tradition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDropDowns(viewModel);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var tradition = _context.Traditions
                .Include(t => t.Holidays)
                .Include(t => t.TraditionParticipants)
                    .ThenInclude(t => t.Participant)
                .FirstOrDefault(t => t.Id == id);

            if (tradition == null)
            {
                return NotFound();
            }

            return View(tradition);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var tradition = await _context.Traditions
                .Include(t => t.Holidays)
                .Include(t => t.TraditionParticipants)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tradition == null)
            {
                return NotFound();
            }

            // Създаваме ViewModel, който ще подадем на изгледа
            var viewModel = new TraditionFormViewModel
            {
                Tradition = tradition,
                Holidays = _context.Holidays.ToList(),
                Participants = _context.Participants.ToList(),
                SelectedHolidayIds = tradition.Holidays.Select(h => h.Id).ToList(),
                SelectedParticipantIds = tradition.TraditionParticipants.Select(tp => tp.ParticipantId).ToList(),
                ParticipantRoles = tradition.TraditionParticipants.ToDictionary(tp => tp.ParticipantId, tp => tp.ParticipantRole ?? string.Empty),
                Regions = new SelectList(EnumHelper.GetRegionSelectListItems(), "Value", "Text", tradition.Region),
                TraditionTypes = new SelectList(EnumHelper.GetTraditionTypeSelectListItems(), "Value", "Text", tradition.TraditionType)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, TraditionFormViewModel viewModel)
        {
            if (id != viewModel.Tradition.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // Load tracked entity from DB
                    var tradition = await _context.Traditions
                        .Include(t => t.Holidays)
                        .Include(t => t.TraditionParticipants)
                        .FirstOrDefaultAsync(t => t.Id == viewModel.Tradition.Id);

                    if (tradition == null)
                    {
                        return NotFound();
                    }

                    _context.Entry(tradition).CurrentValues.SetValues(viewModel.Tradition);

                    // Update Holidays records
                    tradition.Holidays.Clear();

                    if (viewModel.SelectedHolidayIds.Any())
                    {
                        var holidays = await _context.Holidays
                            .Where(h => viewModel.SelectedHolidayIds.Contains(h.Id))
                            .ToListAsync();

                        foreach (var holiday in holidays)
                            tradition.Holidays.Add(holiday);
                    }

                    // Update Participants records
                    tradition.TraditionParticipants.Clear();

                    foreach (var participantId in viewModel.SelectedParticipantIds)
                    {
                        tradition.TraditionParticipants.Add(new TraditionParticipant
                        {
                            ParticipantId = participantId,
                            ParticipantRole = viewModel.ParticipantRoles[participantId]
                        });
                    }

                    // Delete image file on server if there is any
                    if (viewModel.RemoveImage && !string.IsNullOrEmpty(tradition.ImagePath))
                    {
                        string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, tradition.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                        tradition.ImagePath = null;
                    }
                    // Update image if there is a new upload
                    else if (viewModel.ImageFile != null)
                    {
                        // Delete old file first
                        if (!string.IsNullOrEmpty(tradition.ImagePath))
                        {
                            string oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, tradition.ImagePath.TrimStart('/'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Upload new image file - same as Create Action
                        string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "traditions");
                        Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ImageFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await viewModel.ImageFile.CopyToAsync(fileStream);
                        }
                        tradition.ImagePath = "/images/traditions/" + uniqueFileName;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // This happens when another user has just deleted or updated the same record simultaneously
                    if (!_context.Traditions.Any(t => t.Id == viewModel.Tradition.Id))
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
            PopulateDropDowns(viewModel);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tradition = _context.Traditions.Find(id);
            if (tradition != null)
            {
                // Check if there is image path to delete
                if (!string.IsNullOrEmpty(tradition.ImagePath))
                {
                    // Find absolute path to file
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, tradition.ImagePath.TrimStart('/'));

                    // Delete the file if it exists on the server
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                _context.Traditions.Remove(tradition);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        private void PopulateDropDowns(TraditionFormViewModel viewModel)
        {
            viewModel.Holidays = _context.Holidays.ToList();
            viewModel.Participants = _context.Participants.ToList();
            viewModel.Regions = EnumHelper.GetRegionSelectListItems();
            viewModel.TraditionTypes = EnumHelper.GetTraditionTypeSelectListItems();
        }
    }
}
