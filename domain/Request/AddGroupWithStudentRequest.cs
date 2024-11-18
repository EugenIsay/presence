using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class AddGroupWithStudentRequest
    {
        public AddGroupRequest addGroupRequest { get; set; }
        public IEnumerable<AddStudentRequest> addStudentRequests { get; set; }
    }
}
