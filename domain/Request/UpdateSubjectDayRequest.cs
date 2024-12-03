using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class UpdateSubjectDayRequest
    {
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public int SubjectId { get; set; }
    }
}
