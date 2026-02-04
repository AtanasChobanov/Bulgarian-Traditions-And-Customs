using System.Collections.Generic;
using BulgarianTraditionsAndCustoms.Models.Participants;
using BulgarianTraditionsAndCustoms.Models.Traditions;
using BulgarianTraditionsAndCustoms.Validation;
using Microsoft.AspNetCore.Http;

namespace BulgarianTraditionsAndCustoms.ViewModels.Participants
{
    public class ParticipantFormViewModel
    {
        public Participant Participant { get; set; } = new Participant();
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".webp" })]
        public IFormFile? ImageFile { get; set; }
        public bool RemoveImage { get; set; }

        // Only traditions related to this participant
        public ICollection<Tradition>? Traditions { get; set; }
        // IDs of traditions associated with this participant
        public List<int>? SelectedTraditionIds { get; set; } = new();
        // Role of this participant in each related tradition (keyed by TraditionId)
        public Dictionary<int, string>? ParticipantRoles { get; set; } = new();
    }
}
