using SEDC.Homework.WebApi.ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Interfaces
{
   public interface ISubTaskService
    {
        IEnumerable<SubTaskDto> GetUserSubTasks(int userId);
        SubTaskDto GetSubTask(int userId, int todoId, int subTaskId);
        void AddSubTask(SubTaskDto request);
        void DeleteSubTask(int userId, int todoId, int subTaskId);
    }
}
