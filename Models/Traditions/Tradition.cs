using System.ComponentModel.DataAnnotations;
using BulgarianTraditionsAndCustoms.Enums;
using BulgarianTraditionsAndCustoms.Models.Holidays;
using BulgarianTraditionsAndCustoms.Models.Participants;

namespace BulgarianTraditionsAndCustoms.Models.Traditions
{
    public class Tradition
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? CelebrationDate { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public Region Region { get; set; }
        [Required]
        public TraditionType TraditionType { get; set; }
        // Navigation Properties
        public ICollection<Holiday>? Holidays { get; set; }
        public ICollection<TraditionParticipant>? TraditionParticipants { get; set; }
    }
}
