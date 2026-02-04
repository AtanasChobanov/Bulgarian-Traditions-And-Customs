using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models.Participants;

namespace BulgarianTraditionsAndCustoms.ViewModels.Participants
{
    public class ParticipantIndexViewModel
    {
        public PaginatedList<Participant> Participants { get; set; }
        public ParticipantFilterQuery FilterQuery { get; set; }
    }
}
