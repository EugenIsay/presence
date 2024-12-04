namespace Presence.Api.Request
{
    public class PresenceRequest
    {
        public int SubjectDayId { get; set; }
        public int StatusId { get; set; }
        public Guid UserGuid { get; set; }
    }
}
