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
//TODO: REFACTOR SUBTASK SERVICE

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

            var todo = user.ToDos
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

        public void DeleteSubTask(int subTaskId, int todoId, int userId)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new SubTaskException("User with that id does not exist");
            }

            var todo = user.ToDos.FirstOrDefault(x => x.Id == todoId);

            if (todo == null)
            {
                throw new SubTaskException("ToDo with that id does not exist");
            }

            var subTask = todo.SubTasks.FirstOrDefault(x => x.Id == subTaskId);

            if (subTask == null)
            {
                throw new SubTaskException("SubTask with that id does not exist");
            }

            _subTaskRepository.Remove(subTask);

        }

        public SubTaskDto GetSubTask(int subTaskId, int todoId, int userId)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new SubTaskException("User with that id does not exist");
            }

            var todo = user.ToDos.FirstOrDefault(x => x.Id == todoId);

            if (todo == null)
            {
                throw new SubTaskException("ToDo with that id does not exist");
            }

            var subTask = todo.SubTasks.FirstOrDefault(x => x.Id == subTaskId);

            if (subTask == null)
            {
                throw new SubTaskException("SubTask with that id does not exist");
            }

            return new SubTaskDto
            {
                Id = subTask.Id,
                Status = (Status)subTask.Status,
                Text = subTask.Text,
                ToDoId = subTask.ToDoId,
                UserId = userId
            };
        }

        public IEnumerable<SubTaskDto> GetUserSubTasks(int userId)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);    // just to check if user exists

            if (user == null)
            {
                throw new SubTaskException("User with that id does not exist");
            }

            return _todoRepository
                .GetAll()
                .Where(x => x.UserId == userId)
                .SelectMany(x => x.SubTasks)
                .Select(x => new SubTaskDto
                {
                    Id = x.Id,
                    Status = (Status)x.Status,
                    Text = x.Text,
                    ToDoId = x.ToDoId
                });
        }
    }
}
