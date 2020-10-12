using SEDC.Homework.WebApi.ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Interfaces
{
   public interface IToDoService
    {
        IEnumerable<ToDoDto> GetUserToDos(int userId);
        ToDoDto GetToDo(int ToDoId, int userId);
        void AddToDo(ToDoDto request);
        void DeleteToDo(int ToDoId, int userId);
    }
}
