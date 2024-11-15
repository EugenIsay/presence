using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class GroupDAO
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual IEnumerable<UserDAO> Users { get; set; }
        public virtual IEnumerable<GroupSubjectDAO> GroupSubjects { get; set; }
    }
}
