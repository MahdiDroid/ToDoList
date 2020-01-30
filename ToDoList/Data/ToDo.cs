using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Data
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PriorityTypeId { get; set; }
        public PriorityType PriorityType { get; set; }



    }
}