﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entity
{
    public class SubjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<GroupSubjectEntity> GroupsSubject { get; set; }
    }
}
