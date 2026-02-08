using System.ComponentModel.DataAnnotations;
using BulgarianTraditionsAndCustoms.Models.Traditions; // Add this using directive if the Tradition class is in this namespace

namespace BulgarianTraditionsAndCustoms.Models.Holidays
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(100, ErrorMessage = "Максималната дължина е 100 символа.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Датата е задължителна.")]
        [DataType(DataType.Date)]
        public DateTime? CelebrationDate { get; set; }
        [Required(ErrorMessage = "Описанието е задължително.")]
        [MaxLength(2000, ErrorMessage = "Максималната дължина е 2000 символа.")]
        public string Description { get; set; }
        // Navigation Properties
        public ICollection<Tradition>? Traditions { get; set; }
    }
}
