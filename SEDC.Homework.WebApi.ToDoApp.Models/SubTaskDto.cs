using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Models
{
   public class SubTaskDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; }
        public int ToDoId { get; set; }
        public int UserId { get; set; }
    }

    public enum Status
    {
        NotStarted = 1,
        InProgress = 2,
        Finished = 3
    }
}
