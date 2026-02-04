using BulgarianTraditionsAndCustoms.Models.Holidays;
using BulgarianTraditionsAndCustoms.Models.Traditions;
using System.Collections.Generic;

namespace BulgarianTraditionsAndCustoms.ViewModels.Holidays
{
    public class HolidayFormViewModel
    {
        public Holiday Holiday { get; set; } = new Holiday();

        // All traditions so the user can add/remove associations
        public ICollection<Tradition> Traditions { get; set; } = new List<Tradition>();

        // IDs of traditions associated with this holiday
        public List<int> SelectedTraditionIds { get; set; } = new();
    }
}
