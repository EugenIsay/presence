﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entity
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserEntity>? users { get; set; } = null;
        public IEnumerable<GroupSubjectEntity>? groupSubjects { get; set; } = null;
    }
}
