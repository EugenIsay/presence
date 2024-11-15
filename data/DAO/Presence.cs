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
        public Guid UserGuid { get; set; }
        public virtual SubjectDayDAO SubjectDay { get; set; }
        public int SubjectDayId { get; set; }
        public virtual StatusDAO Status { get; set; }
        public int StatusId { get; set; }
    }
}
