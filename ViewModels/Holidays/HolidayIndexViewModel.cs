using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models.Holidays;

namespace BulgarianTraditionsAndCustoms.ViewModels.Holidays
{
    public class HolidayIndexViewModel
    {
        public PaginatedList<Holiday> Holidays { get; set; }
        public HolidayFilterQuery FilterQuery { get; set; }
    }
}
