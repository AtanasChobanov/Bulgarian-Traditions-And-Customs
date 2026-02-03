namespace BulgarianTraditionsAndCustoms.Models
{
    public class ParticipantFilterQuery
    {
        public string? SearchString { get; set; }
        public string SortOrder { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
