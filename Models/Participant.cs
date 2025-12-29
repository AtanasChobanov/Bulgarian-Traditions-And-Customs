using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string? Role { get; set; }
        [Url]
        public string? ImagePath { get; set; }
        // Navigation Properties
        public ICollection<TraditionParticipant> TraditionParticipants { get; set; }
    }
}
