using SEDC.Homework.WebApi.ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Interfaces
{
   public interface ISubTaskService
    {
        IEnumerable<SubTaskDto> GetUserSubTasks(int todoId);
        SubTaskDto GetSubTask(int SubTaskId, int todoId);
        void AddSubTask(SubTaskDto request);
        void DeleteSubTask(int SubTaskId, int todoId);
    }
}
