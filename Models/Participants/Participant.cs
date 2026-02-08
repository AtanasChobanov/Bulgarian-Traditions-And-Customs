using System.ComponentModel.DataAnnotations;

namespace BulgarianTraditionsAndCustoms.Models.Participants
{
    public class Participant
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(100, ErrorMessage = "Максималната дължина е 100 символа.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описанието е задължително.")]
        [MaxLength(2000, ErrorMessage = "Максималната дължина е 2000 символа.")]
        public string Description { get; set; }
        [MaxLength(200, ErrorMessage = "Максималната дължина е 200 символа.")]
        public string? Role { get; set; }
        public string? ImagePath { get; set; }
        // Navigation Properties
        public ICollection<TraditionParticipant>? TraditionParticipants { get; set; }
    }
}
