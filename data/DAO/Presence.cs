using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class PresenceDAO
    {
        public virtual UserDAO User { get; set; }
        public virtual SubjectDayDAO SubjectDay { get; set; }
        public virtual StatusDAO Status { get; set; }
    }
}
