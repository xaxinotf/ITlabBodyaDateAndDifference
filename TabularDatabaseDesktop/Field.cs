﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabularDatabaseDesktop
{
    public enum DataType
    {
        Integer,
        Real,
        Char,
        String,
        Date,
        DateInterval
    }

    public class Field
    {
        public string Name { get; set; }
        public DataType Type { get; set; }

        public Field(string name, DataType type)
        {
            Name = name;
            Type = type;
        }
    }
}
