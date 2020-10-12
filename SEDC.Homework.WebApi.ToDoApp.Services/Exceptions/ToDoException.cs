using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Exceptions
{
   public class ToDoException : Exception
    {
        public int? UserId { get; set; }
        public int? ToDoId { get; set; }
        public string Name { get; set; }

        public ToDoException(string message)
            : base(message)
        {

        }

        public ToDoException(int? userId, int? todoId, string name)
            : base("There has been an issue with user or todo")
        {
            UserId = userId;
            ToDoId = todoId;
            Name = name;
        }

        public ToDoException(int? userId, int? todoId, string name, string message)
        {
            UserId = userId;
            ToDoId = todoId;
            Name = name;
        }
        
    }
}
