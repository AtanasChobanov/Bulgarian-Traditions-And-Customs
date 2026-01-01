using BulgarianTraditionsAndCustoms.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class TraditionFormViewModel
    {
        public Tradition Tradition { get; set; } = new Tradition();
        public IFormFile? ImageFile { get; set; }
        public bool RemoveImage { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Regions { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TraditionTypes { get; set; }
        public List<int> SelectedHolidayIds { get; set; } = new();
        public List<int> SelectedParticipantIds { get; set; } = new();
        [ValidateNever]
        public MultiSelectList Holidays { get; set; }
        [ValidateNever]
        public MultiSelectList Participants { get; set; }
    }
}
