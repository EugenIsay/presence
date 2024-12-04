using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class ChangeUsersGroupRequest
    {
        public int GroupId { get; set; }
        public List<Guid> UsersGuids { get; set; }
    }
}
