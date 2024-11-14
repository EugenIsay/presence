using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class SubjectDAO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<GroupSubjectDAO> GroupsSubject { get; set; }
        public virtual IEnumerable<SubjectDayDAO> SubjectDays { get; set; }
    }
}
