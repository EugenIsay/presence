using domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Request
{
    public class AddGroupSubjectsRequest
    {
        public int GroupId { get; set; }
        public List<SemestrSubject> subjects { get; set; }

    }
}
