using BulgarianTraditionsAndCustoms.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class ParticipantFormViewModel
    {
        public Participant Participant { get; set; } = new Participant();

        // Only traditions related to this participant
        public ICollection<Tradition> Traditions { get; set; } = new List<Tradition>();

        // IDs of traditions associated with this participant
        public List<int> SelectedTraditionIds { get; set; } = new();

        // File upload for participant image
        public IFormFile? ImageFile { get; set; }
        public bool RemoveImage { get; set; }

        // Role of this participant in each related tradition (keyed by TraditionId)
        public Dictionary<int, string> ParticipantRoles { get; set; } = new();
    }
}
