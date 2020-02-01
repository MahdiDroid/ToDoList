using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Dtos;
using ToDoList.Data;
namespace ToDoList
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            Mapper.CreateMap<ToDo, ToDoDto>();
        }
    }
}