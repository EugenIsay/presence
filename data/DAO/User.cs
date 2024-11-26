using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class UserDAO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public virtual GroupDAO Group { get; set; }
        public virtual IEnumerable<PresenceDAO> Presences { get; set; }
        public string GroupName => Group.GroupName;
    }
}
