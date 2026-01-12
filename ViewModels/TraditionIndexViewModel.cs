using BulgarianTraditionsAndCustoms.Models;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class TraditionIndexViewModel
    {
        public IEnumerable<Tradition> Traditions { get; set; } = [];
        public TraditionFilterQuery FilterQuery { get; set; }
    }
}
