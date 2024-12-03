using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entity
{
    public class SubjectDayEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public virtual SubjectEntity Subject { get; set; }
    }
}
