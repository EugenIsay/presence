
namespace Presence.Api.Response
{
    public class PresenceResponse
    {
        public virtual UserResponse User { get; set; }
        public virtual SubjectDayResponse SubjectDay { get; set; }
        public virtual StatusResponse Status { get; set; }
    }
}
