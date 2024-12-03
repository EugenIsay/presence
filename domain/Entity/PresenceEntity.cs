using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entity
{
    public class PresenceEntity
    {
        public virtual UserEntity User { get; set; }
        public virtual SubjectDayEntity SubjectDay { get; set; }
        public int Status { get; set; }
    }
}
