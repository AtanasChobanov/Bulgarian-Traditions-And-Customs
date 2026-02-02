using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class HolidayIndexViewModel
    {
        public PaginatedList<Holiday> Holidays { get; set; }
        public HolidayFilterQuery FilterQuery { get; set; }
    }
}
