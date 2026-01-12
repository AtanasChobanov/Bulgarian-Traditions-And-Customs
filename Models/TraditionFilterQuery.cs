using BulgarianTraditionsAndCustoms.Enums;
using BulgarianTraditionsAndCustoms.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianTraditionsAndCustoms.Models
{
    public class TraditionFilterQuery
    {
        public string? SearchString { get; set; }
        [ModelBinder(BinderType = typeof(CsvModelBinder<TraditionType>))]
        public List<TraditionType>? TraditionTypes { get; set; } = new();
        [ModelBinder(BinderType = typeof(CsvModelBinder<Region>))]
        public List<Region>? Regions { get; set; } = new();
        [ModelBinder(BinderType = typeof(CsvModelBinder<int>))]
        public List<int>? HolidayIds { get; set; } = new();
        [ModelBinder(BinderType = typeof(CsvModelBinder<int>))]
        public List<int>? ParticipantIds { get; set; } = new();

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public string SortOrder { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
