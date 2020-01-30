using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public DbSet<> MyProperty { get; set; }
    }
}