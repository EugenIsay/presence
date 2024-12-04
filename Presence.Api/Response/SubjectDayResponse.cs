

namespace Presence.Api.Response
{
    public class SubjectDayResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public virtual SubjectResponse Subject { get; set; }
    }
}
