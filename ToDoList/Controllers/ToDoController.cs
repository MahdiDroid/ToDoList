using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var toDos = _db.ToDos.ToList();
            return View(toDos);
        }
    }
}