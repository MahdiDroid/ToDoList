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

        public ActionResult Index()
        {
            var toDos = _db.ToDos.Include(t => t.PriorityType).ToList();
            
            return View(toDos);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var todoInDb = _db.ToDos.Include(t => t.PriorityType).SingleOrDefault(t => t.Id == id);
            
            return View(todoInDb);
        }


       [HttpGet]
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
        public ActionResult Create(ToDo todo)
        {
            
            todo.IsDone = false;
            _db.ToDos.Add(todo);

            _db.SaveChanges();
            return RedirectToAction("Index", "ToDo");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            var todoInDb = _db.ToDos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                HttpNotFound();
            }

            var pt = _db.PriorityTypes.ToList();
            var priorityTypeVm = new PriorityTypeViewModel
            {
                Todo= todoInDb,
                PriorityType = pt,
            };
            return View(priorityTypeVm);

        }
        [HttpPost]
        public ActionResult Update(ToDo todo)
        {
            var todoInDb = _db.ToDos.SingleOrDefault(t => t.Id == todo.Id);
            todoInDb.Title = todo.Title;
            todoInDb.IsDone = todo.IsDone;
            todoInDb.Description = todo.Description;
            todoInDb.Date = todo.Date;
            todoInDb.PriorityTypeId = todo.PriorityTypeId;

            _db.SaveChanges();

            return RedirectToAction("Index","ToDo");

        }

        [HttpPut]
        public ActionResult UpdateIsDoneStatus(int id)
        {
            var todoInDb = _db.ToDos.SingleOrDefault(t => t.Id == id);
            todoInDb.IsDone = true;
            _db.SaveChanges();

            return RedirectToAction("Index", "ToDo");
        }
        
        public ActionResult Delete(int id)
        {
            var todo = _db.ToDos.Include(t=>t.PriorityType).SingleOrDefault(t => t.Id == id);

            return View(todo);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var todoToDelete = _db.ToDos.SingleOrDefault(t => t.Id == id);
            _db.ToDos.Remove(todoToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDO");
        }
            
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }

}