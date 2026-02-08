using System.ComponentModel.DataAnnotations;
using BulgarianTraditionsAndCustoms.Models.Traditions; // Add this using directive if the Tradition class is in this namespace

namespace BulgarianTraditionsAndCustoms.Models.Holidays
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? CelebrationDate { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        // Navigation Properties
        public ICollection<Tradition>? Traditions { get; set; }
    }
}
