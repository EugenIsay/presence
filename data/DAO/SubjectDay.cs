﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DAO
{
    public class SubjectDayDAO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Order {  get; set; }
        public virtual SubjectDAO Subject { get; set; }
    }
}
