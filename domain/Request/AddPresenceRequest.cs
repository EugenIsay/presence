using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class AddPresenceRequest
    {
        public Guid UserGuid { get; set; }
        public int SubjectDayId { get; set; }
        public int StatusId { get; set; }
    }
}
