using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public int GroupId { get; set; }
    }
}
