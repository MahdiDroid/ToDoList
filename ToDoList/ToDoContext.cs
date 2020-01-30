using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoList.Data;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public DbSet<PriorityType> PriorityTypes { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

    }
}