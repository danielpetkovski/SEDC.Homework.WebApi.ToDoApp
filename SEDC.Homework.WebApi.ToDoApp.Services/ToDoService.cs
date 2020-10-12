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
    public class ToDoService : IToDoService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ToDo> _todoRepository;
       // private readonly IRepository<SubTask> _subtaskRepository;

        public ToDoService(IRepository<User> userRepository,
            IRepository<ToDo> todoRepository)
           // IRepository<SubTask> subtaskRepository)
        {
            _userRepository = userRepository;
            _todoRepository = todoRepository;
           // _subtaskRepository = subtaskRepository;
        }
        public void AddToDo(ToDoDto request)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
            {
                throw new ToDoException("User does not exist");
            }

            if (string.IsNullOrWhiteSpace(request.Text))
            {
                throw new ToDoException("Text is a required field");
            }

            if (string.IsNullOrWhiteSpace(request.Color))
            {
                throw new ToDoException("Color is a required field");
            }

            var todo = new ToDo
            {
                Text = request.Text,
                Color = request.Color,
                UserId = request.UserId,
            };

            _todoRepository.Insert(todo);

        }

        public void DeleteToDo(int toDoId, int userId)
        {
            var todo = _todoRepository
                .GetAll()
                .FirstOrDefault(x => x.Id == toDoId && x.UserId == userId);

            if (todo == null)
            {
                throw new ToDoException("ToDo with that id does not exist");
            }

            _todoRepository.Remove(todo);
        }

        public ToDoDto GetToDo(int toDoId, int userId)
        {
            var todo = _todoRepository
                .GetAll()
                .FirstOrDefault(x => x.Id == toDoId && x.UserId == userId);

            if (todo == null)
            {
                throw new ToDoException("ToDo with that id does not exist");
            }

            return new ToDoDto
            {
                Id = todo.Id,
                Color = todo.Color,
                Text = todo.Text,
                UserId = todo.UserId
            };

        }

        public IEnumerable<ToDoDto> GetUserToDos(int userId)
        {
            return _todoRepository
                .GetAll()
                .Where(x => x.UserId == userId)
                .Select(x => new ToDoDto
                {
                    Color = x.Color,
                    Id = x.Id,
                    Text = x.Text,
                    UserId = x.UserId
                });
        }
    }
}
