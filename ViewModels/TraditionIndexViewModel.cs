using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class TraditionIndexViewModel
    {
        public PaginatedList<Tradition> Traditions { get; set; }
        public TraditionFilterQuery FilterQuery { get; set; }
    }
}
