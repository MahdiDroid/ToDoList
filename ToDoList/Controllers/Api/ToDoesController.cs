using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Data;
using ToDoList.Dtos;

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
        public IEnumerable<ToDoDto> ToDoes()
        {
            //return Ok(db.ToDos.ToList());
            return db.ToDos.ToList().Select(Mapper.Map<ToDo,ToDoDto>);
        }

        [HttpGet]
        public ToDoDto Todoes(int id)
        {
            var todo = db.ToDos.SingleOrDefault(t => t.Id == id);
            if (todo == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return Mapper.Map<ToDo,ToDoDto>(todo);
        }

        [HttpPost]
        public ToDoDto Create(ToDoDto tododto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var todo = Mapper.Map<ToDoDto, ToDo>(tododto);
            db.ToDos.Add(todo);
            db.SaveChanges();
            tododto.Id = todo.Id;
            return tododto;
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id,ToDoDto todoDto)
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
            var todo = Mapper.Map<ToDoDto, ToDo>(todoDto);

            todoInDb.Title = todo.Title;

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
