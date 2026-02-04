namespace BulgarianTraditionsAndCustoms.Models
{
    public class DeleteModalViewModel
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string DisplayTitle { get; set; }
        public string Action { get; set; } = "Delete";
        public string Controller { get; set; }
    }
}
