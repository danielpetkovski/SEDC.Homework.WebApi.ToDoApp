using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Exceptions
{
   public class SubTaskException : Exception
    {
        public int? ToDoId { get; set; }
        public int? SubTaskId { get; set; }
        public string Name { get; set; }

        public SubTaskException(string message)
            : base(message)
        {
        }

        public SubTaskException(int? todoId, int? subtaskId, string name)
            : base("There has been an issue with user or todo")
        {
            ToDoId = todoId;
            SubTaskId = subtaskId;
            Name = name;
        }
    }
}
