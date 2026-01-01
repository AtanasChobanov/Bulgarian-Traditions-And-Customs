using BulgarianTraditionsAndCustoms.Data;
using BulgarianTraditionsAndCustoms.Models;
using BulgarianTraditionsAndCustoms.ViewModels;
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

        public IActionResult Index()
        {
            var traditionsList = _context.Traditions
                .Include(t => t.TraditionType)
                .Include(t => t.Region)
                .ToList();

            return View(traditionsList);
        }

        public IActionResult Create()
        {
            var viewModel = new TraditionFormViewModel();
            PopulateCreateFormDropDowns(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    viewModel.Tradition.TraditionParticipants.Add(new TraditionParticipant { ParticipantId = participantId });
                }

                // Save to DB
                _context.Traditions.Add(viewModel.Tradition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCreateFormDropDowns(viewModel);
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var tradition = _context.Traditions
                                  .Include(t =>t.TraditionType)
                                  .Include(t => t.Region)
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

        public IActionResult Delete(int id)
        {
            var tradition = _context.Traditions
                                  .Include(t => t.TraditionType)
                                  .Include(t => t.Region)
                                  .FirstOrDefault(t => t.Id == id);
            if (tradition == null)
            {
                return NotFound();
            }

            return View(tradition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        private void PopulateCreateFormDropDowns(TraditionFormViewModel viewModel)
        {
            PopulateDropDowns(viewModel);
            viewModel.Holidays = new MultiSelectList(_context.Holidays, "Id", "Name");
            viewModel.Participants = new MultiSelectList(_context.Participants, "Id", "Name");
        }

        private void PopulateDropDowns(TraditionFormViewModel viewModel)
        {
            viewModel.Regions = new SelectList(_context.Regions, "Id", "Name");
            viewModel.TraditionTypes = new SelectList(_context.TraditionTypes, "Id", "Name");
        }
    }
}
