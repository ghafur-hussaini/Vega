﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi1.Models
{
    public class ToDoItems
    {
        public long  Id { get; set; }
        public String Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
