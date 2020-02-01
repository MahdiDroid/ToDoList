using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Data;

namespace ToDoList.Controllers.Api
{
    public class ToDoesController : ApiController
    {
        private ToDoContext db;
        public ToDoesController()
        {
            db = new ToDoContext();
        }


        //api/todoes
        [HttpGet]
        public IEnumerable<ToDoDTO> ToDoes()
        {
            //return Ok(db.ToDos.ToList());
            return db.ToDos.ToList();
        }

        [HttpGet]
        public ToDo Todoes(int id)
        {
            var todo = db.ToDos.SingleOrDefault(t => t.Id == id);
            if (todo == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return todo;
        }

        [HttpPost]
        public ToDo Create(ToDo todo)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            db.ToDos.Add(todo);
            db.SaveChanges();
            return todo;
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id,ToDo todo)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var todoInDb = db.ToDos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            todoInDb.IsDone = todo.IsDone;
            todoInDb.Description = todo.Description;
            todoInDb.PriorityTypeId = todo.PriorityTypeId;
            todoInDb.Date = todo.Date;
            //db.ToDos.Add(todoInDb);
            db.SaveChanges();
            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var todoInDb = db.ToDos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.ToDos.Remove(todoInDb);
            db.SaveChanges();
            return Ok(HttpStatusCode.OK);
        }
    }
}
