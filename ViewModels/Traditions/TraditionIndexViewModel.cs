using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models.Traditions;

namespace BulgarianTraditionsAndCustoms.ViewModels.Traditions
{
    public class TraditionIndexViewModel
    {
        public PaginatedList<Tradition> Traditions { get; set; }
        public TraditionFilterQuery FilterQuery { get; set; }
    }
}
