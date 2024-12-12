﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presence.Desktop.Models
{
    public class UserPresenter
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public GroupPresenter Group { get; set; }
    }
}
