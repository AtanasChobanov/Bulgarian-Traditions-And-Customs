using BulgarianTraditionsAndCustoms.Helpers;
using BulgarianTraditionsAndCustoms.Models;

namespace BulgarianTraditionsAndCustoms.ViewModels
{
    public class ParticipantIndexViewModel
    {
        public PaginatedList<Participant> Participants { get; set; }
        public ParticipantFilterQuery FilterQuery { get; set; }
    }
}
