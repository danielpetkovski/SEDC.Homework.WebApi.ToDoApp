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
        private readonly IRepository<SubTask> _subtaskRepository;

        public SubTaskService(IRepository<User> userRepository,
            IRepository<ToDo> todoRepository,
            IRepository<SubTask> subtaskRepository)
        {
            _userRepository = userRepository;
            _todoRepository = todoRepository;
            _subtaskRepository = subtaskRepository;
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

            _subtaskRepository.Insert(subTask);

        }

        public void DeleteSubTask(int subTaskId, int todoId, int userId)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new SubTaskException("User with that id does not exist");
            }

            var todo = _todoRepository.GetAll().FirstOrDefault(x => x.Id == todoId);

            if (todo == null)
            {
                throw new SubTaskException("ToDo with that id does not exist");
            }

            var subTask = _subtaskRepository.GetAll().FirstOrDefault(x => x.Id == subTaskId);

            if (subTask == null)
            {
                throw new SubTaskException("SubTask with that id does not exist");
            }

            _subtaskRepository.Remove(subTask);

        }
        //TODO: Combine user todo and subtaskid to check together
        public SubTaskDto GetSubTask(int subTaskId, int todoId, int userId)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new SubTaskException("User with that id does not exist");
            }

            var todo = _todoRepository.GetAll().FirstOrDefault(x => x.Id == todoId);

            if (todo == null)
            {
                throw new SubTaskException("ToDo with that id does not exist");
            }

            var subTask = _subtaskRepository.GetAll().FirstOrDefault(x => x.Id == subTaskId);

            if (subTask == null)
            {
                throw new SubTaskException("SubTask with that id does not exist");
            }

            return new SubTaskDto
            {
                //TODO: u dont need Ids returned, Status 
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

            var toDo = _todoRepository
                .GetAll()
                .Where(x => x.UserId == userId);

            if (toDo == null)
            {
                throw new SubTaskException("That user does not have any ToDos");
            }

            var toDos = toDo.Select(x => new ToDoDts
            {
                Color = x.Color,
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                SubTasks = _subtaskRepository
                    .GetAll()
                    .Where(y => y.ToDoId == x.Id)
                    .Select(z => new SubTaskDto
                    {
                        Id = z.Id,
                        Text = z.Text,
                        Status = (Status)z.Status,
                        ToDoId = z.ToDoId
                    })
            });

            var subTasks = toDos.SelectMany(x => x.SubTasks);

            if (!subTasks.Any())
            {
                throw new SubTaskException("That user does not have any SubTasks");
            }

            return subTasks;
        }
    }
}
