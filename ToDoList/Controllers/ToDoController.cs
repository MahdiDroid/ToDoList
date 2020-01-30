using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ToDoList.Data;
using ToDoList.ViewModel;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private ToDoContext _db;
        public ToDoController()
        {
            _db = new ToDoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        public ActionResult Index()
        {
            var toDos = _db.ToDos.Include(t => t.PriorityType).ToList();
            
            return View(toDos);
        }
       
        public ActionResult Create()
        {
            var  pt = _db.PriorityTypes.ToList();

            var priorityTypeVm = new PriorityTypeViewModel
            {
                PriorityType = pt,
            };
            return View(priorityTypeVm);

        }
        [HttpPost]
        public ActionResult Save(ToDo todo)
        {
            todo.Date = DateTime.Now;
            todo.IsDone = false;

            _db.ToDos.Add(todo);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDo");
        }

        [HttpPut]
        public ActionResult UpdateIsDoneStatus(int id)
        {
            var todoInDb = _db.ToDos.SingleOrDefault(t => t.Id == id);
            todoInDb.IsDone = true;
            _db.SaveChanges();

            return RedirectToAction("Index", "ToDo");

        }
    }
}