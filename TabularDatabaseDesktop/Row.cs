﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularDatabaseDesktop
{
    public class Row
    {
        public Dictionary<string, object> Values { get; set; }

        public Row()
        {
            Values = new Dictionary<string, object>();
        }
    }
}
