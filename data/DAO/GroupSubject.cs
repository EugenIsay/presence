using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class GroupSubjectDAO
    {
        public virtual GroupDAO Group { get; set; }
        public int GroupId { get; set; }
        public virtual SubjectDAO Subject { get; set; }
        public int SubjectId { get; set; }
        public int Semester { get; set; }
    }
}
