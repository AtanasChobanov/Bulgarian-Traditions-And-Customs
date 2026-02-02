namespace BulgarianTraditionsAndCustoms.Models
{
    public class HolidayFilterQuery
    {
        public string? SearchString { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string SortOrder { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
