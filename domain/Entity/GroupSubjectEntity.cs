﻿using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entity
{
    public class GroupSubjectEntity
    {
        public virtual GroupEntity Group { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public int Semester { get; set; }
    }
}
