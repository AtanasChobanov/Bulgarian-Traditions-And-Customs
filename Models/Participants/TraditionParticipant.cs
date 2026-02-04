using System.ComponentModel.DataAnnotations;
using BulgarianTraditionsAndCustoms.Models.Traditions;

namespace BulgarianTraditionsAndCustoms.Models.Participants
{
    public class TraditionParticipant
    {
        public int TraditionId { get; set; }
        public int ParticipantId { get; set; }
        [MaxLength(200)]
        public string? ParticipantRole { get; set; }
        // Navigation Properties
        public Tradition Tradition { get; set; }
        public Participant Participant { get; set; }
    }
}
