using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels
{
   public class ToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<SubTask> SubTasks { get; set; }
    }
}
