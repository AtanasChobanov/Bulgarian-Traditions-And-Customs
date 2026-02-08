using System.ComponentModel.DataAnnotations;
using BulgarianTraditionsAndCustoms.Enums;
using BulgarianTraditionsAndCustoms.Models.Holidays;
using BulgarianTraditionsAndCustoms.Models.Participants;

namespace BulgarianTraditionsAndCustoms.Models.Traditions
{
    public class Tradition
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(100, ErrorMessage = "Максималната дължина е 100 символа.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описанието е задължително.")]
        [MaxLength(2000, ErrorMessage = "Максималната дължина е 2000 символа.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Датата е задължителна.")]
        [DataType(DataType.Date)]
        public DateTime? CelebrationDate { get; set; }
        public string? ImagePath { get; set; }
        [Required(ErrorMessage = "Регионът е задължителен.")]
        public Region Region { get; set; }
        [Required(ErrorMessage = "Типът на традицията е задължителен.")]
        public TraditionType TraditionType { get; set; }
        // Navigation Properties
        public ICollection<Holiday>? Holidays { get; set; }
        public ICollection<TraditionParticipant>? TraditionParticipants { get; set; }
    }
}
