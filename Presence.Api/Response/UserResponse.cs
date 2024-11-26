using data.DAO;

namespace Presence.Api.Response
{
    public class UserResponse
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public GroupResponse Group { get; set; }

    }
}
