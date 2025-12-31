using BulgarianTraditionsAndCustoms.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class TraditionFormViewModel
    {
        public Tradition Tradition { get; set; } = new Tradition();
        public IFormFile? ImageFile { get; set; }
        public bool RemoveImage { get; set; }
        public IEnumerable<SelectListItem> Regions { get; set; }
        public IEnumerable<SelectListItem> TraditionTypes { get; set; }
        public List<int> SelectedHolidayIds { get; set; } = new();
        public List<int> SelectedParticipantIds { get; set; } = new();
        public MultiSelectList Holidays { get; set; }
        public MultiSelectList Participants { get; set; }
    }
}
