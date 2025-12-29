using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Models
{
    public class TraditionType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string? Description { get; set; }
        // Navigation Properties
        public ICollection<Tradition>? Traditions { get; set; }
    }
}
