namespace Presence.Api.Request
{
    public class GroupUsersRequest
    {
        public string Name { get; set; }
        public List<UserRequest> Users { get; set; }
    }
}
