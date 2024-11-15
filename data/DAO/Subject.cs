using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class SubjectDAO
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual IEnumerable<GroupSubjectDAO> GroupsSubject { get; set; }
        public virtual IEnumerable<SubjectDayDAO> SubjectDays { get; set; }
    }
}
