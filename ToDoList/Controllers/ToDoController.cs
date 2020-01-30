﻿using System;
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
       
        public ActionResult New()
        {

            var priorityTypeVm = new PriorityTypeViewModel
            {
                PriorityType = _db.PriorityTypes.ToList()
            };
            return View(priorityTypeVm);

        }
        [HttpPost]
        public ActionResult Save(ToDo todo)
        {
            _db.ToDos.Add(todo);
            _db.SaveChanges();
            return RedirectToAction("Index", "ToDo");

        }
    }
}