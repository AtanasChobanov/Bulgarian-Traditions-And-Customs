using BulgarianTraditionsAndCustoms.Data;
using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models.Holidays;
using BulgarianTraditionsAndCustoms.Models.Traditions;
using BulgarianTraditionsAndCustoms.ViewModels;
using BulgarianTraditionsAndCustoms.ViewModels.Holidays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Controllers
{
    public class HolidaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HolidaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(HolidayFilterQuery query)
        {
            // ===== 1. Основна заявка =====

            var holidaysQuery = _context.Holidays.Include(h => h.Traditions).AsQueryable();

            // ===== 2. Търсене =====

            if (!string.IsNullOrWhiteSpace(query.SearchString))
            {
                holidaysQuery = holidaysQuery.Where(h => h.Name.Contains(query.SearchString));
            }

            // ===== 3. Филтриране по период =====

            if (query.DateFrom.HasValue && !query.DateTo.HasValue)
            {
                holidaysQuery = holidaysQuery
                    .Where(h => h.CelebrationDate.Date == query.DateFrom.Value.Date);
            }
            else if (!query.DateFrom.HasValue && query.DateTo.HasValue)
            {
                holidaysQuery = holidaysQuery
                    .Where(h => h.CelebrationDate.Date == query.DateTo.Value.Date);
            }
            else if (query.DateFrom.HasValue && query.DateTo.HasValue)
            {
                holidaysQuery = holidaysQuery
                    .Where(h => h.CelebrationDate.Date >= query.DateFrom.Value.Date &&
                                h.CelebrationDate.Date <= query.DateTo.Value.Date);
            }

            // ===== 4. Сортиране =====

            holidaysQuery = query.SortOrder switch
            {
                "name_desc" => holidaysQuery.OrderByDescending(h => h.Name),
                "upcoming" => holidaysQuery.OrderBy(h => h.CelebrationDate),
                _ => holidaysQuery.OrderBy(h => h.Name)
            };

            // ===== 5. Странициране =====

            var paginatedHolidays = await PaginatedList<Holiday>.CreateAsync(holidaysQuery, query.PageNumber, query.PageSize);

            // Create ViewModel
            var viewModel = new HolidayIndexViewModel
            {
                Holidays = paginatedHolidays,
                FilterQuery = query
            };

            return View(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new HolidayFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(HolidayFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Holidays.Add(viewModel.Holiday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var holiday = _context.Holidays
                .Include(h => h.Traditions)
                .FirstOrDefault(h => h.Id == id);

            if (holiday == null)
            {
                return NotFound();
            }

            return View(holiday);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var holiday = await _context.Holidays
                .Include(h => h.Traditions)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (holiday == null)
            {
                return NotFound();
            }

            // Build a form view model with only traditions related to this holiday.
            var relatedTraditions = holiday.Traditions?.ToList() ?? new List<Tradition>();
            var viewModel = new HolidayFormViewModel
            {
                Holiday = holiday,
                Traditions = relatedTraditions,
                SelectedTraditionIds = relatedTraditions.Select(t => t.Id).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, HolidayFormViewModel viewModel)
        {
            if (id != viewModel.Holiday.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Load tracked entity from DB including current relations
                    var holiday = await _context.Holidays
                        .Include(h => h.Traditions)
                        .FirstOrDefaultAsync(h => h.Id == viewModel.Holiday.Id);

                    if (holiday == null)
                    {
                        return NotFound();
                    }

                    // Update scalar properties
                    _context.Entry(holiday).CurrentValues.SetValues(viewModel.Holiday);

                    // Update related traditions
                    holiday.Traditions.Clear();
                    if (viewModel.SelectedTraditionIds.Any())
                    {
                        var selected = await _context.Traditions
                            .Where(t => viewModel.SelectedTraditionIds.Contains(t.Id))
                            .ToListAsync();

                        foreach (var t in selected)
                            holiday.Traditions.Add(t);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // This happens when another user has just deleted or updated the same record simultaneously
                    if (!_context.Holidays.Any(h => h.Id == viewModel.Holiday.Id))
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

            // If we got this far, something failed; ensure the traditions list (related ones) is available for the view
            viewModel.Traditions = _context.Holidays
                .Include(h => h.Traditions)
                .Where(h => h.Id == viewModel.Holiday.Id)
                .SelectMany(h => h.Traditions)
                .ToList();
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var holiday = _context.Holidays.Find(id);
            if (holiday == null)
            {
                return NotFound();
            }

            // Check for related traditions that reference this holiday
            var hasTraditions = _context.Traditions.Any(t => t.Holidays.Any(h => h.Id == id));
            if (hasTraditions)
            {
                TempData["ErrorMessage"] = "Не може да изтриете този празник, защото има свързани с него традиции!";
                return RedirectToAction(nameof(Index));
            }

            _context.Holidays.Remove(holiday);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Празникът беше успешно изтрит.";
            return RedirectToAction(nameof(Index));
        }
    }
}
