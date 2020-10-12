using SEDC.Homework.WebApi.ToDoApp.DataAccess;
using SEDC.Homework.WebApi.ToDoApp.DataModels;
using SEDC.Homework.WebApi.ToDoApp.Models;
using SEDC.Homework.WebApi.ToDoApp.Services.Exceptions;
using SEDC.Homework.WebApi.ToDoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services
{
    public class SubTaskService : ISubTaskService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ToDo> _todoRepository;
        private readonly IRepository<SubTask> _subTaskRepository;

        public SubTaskService(IRepository<User> userRepository,
            IRepository<ToDo> todoRepository,
            IRepository<SubTask> subTaskRepository)
        {
            _userRepository = userRepository;
            _todoRepository = todoRepository;
            _subTaskRepository = subTaskRepository;
        }

        public void AddSubTask(SubTaskDto request)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new SubTaskException("User does not exist");
            }

            var todo = _todoRepository.GetAll()
                .FirstOrDefault(x => x.Id == request.ToDoId);

            if (todo == null)
            {
                throw new SubTaskException("ToDo does not exist");
            }

            if (string.IsNullOrWhiteSpace(request.Text))
            {
                throw new SubTaskException("Text field is required");
            }

            if ((int)request.Status < 1 || (int)request.Status > 3)
            {
                throw new SubTaskException("Status is required and should be between 1 and 3");
            }

            var subTask = new SubTask
            {
                Text = request.Text,
                Status = (int)request.Status,
                ToDoId = request.ToDoId
            };

            _subTaskRepository.Insert(subTask);

        }

        public void DeleteSubTask(int subTaskId, int todoId)
        {
            throw new NotImplementedException();
        }

        public SubTaskDto GetSubTask(int subTaskId, int todoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubTaskDto> GetUserSubTasks(int todoId)
        {
            throw new NotImplementedException();
        }
    }
}
