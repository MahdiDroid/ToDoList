﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Data;

namespace ToDoList.ViewModel
{
    public class PriorityTypeViewModel
    {
        public IEnumerable<PriorityType> PriorityType { get; set; }
        public ToDo Todo { get; set; }
    }
}