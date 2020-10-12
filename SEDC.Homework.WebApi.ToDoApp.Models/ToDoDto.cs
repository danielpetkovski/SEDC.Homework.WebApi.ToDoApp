using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Models
{
   public class ToDoDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
    }
}
