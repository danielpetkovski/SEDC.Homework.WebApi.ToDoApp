using SEDC.Homework.WebApi.ToDoApp.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels
{
   public class SubTask
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }

        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }

        
    }
}
