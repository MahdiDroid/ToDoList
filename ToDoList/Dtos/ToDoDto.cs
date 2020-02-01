using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Dtos
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
        public int PriorityTypeId { get; set; }
    }
}