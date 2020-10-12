using SEDC.Homework.WebApi.ToDoApp.DataAccess;
using SEDC.Homework.WebApi.ToDoApp.DataModels;
using SEDC.Homework.WebApi.ToDoApp.Models;
using SEDC.Homework.WebApi.ToDoApp.Services.Exceptions;
using SEDC.Homework.WebApi.ToDoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x =>
                    x.UserName == username);

            if (user == null)
            {
                throw new UserException(null, null,
                        "User with that username does not exist");
            }

            var hashedPassword = HashPassword(password);

            if (user.Password != hashedPassword)
            {
                throw new UserException(user.Id, user.Password,
                    "User password does not match with user");
            }


            var userModel = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return userModel;
        }

        public void Register(RegisterModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                throw new UserException(null, request.Password,
                    "Password is required");
            }

            if (request.Password != request.ConfirmPassword)
            {
                throw new UserException(null, request.Password,
                    "Passwords dont match");
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new UserException(null, request.FirstName,
                    "Firstname is required");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new UserException(null, request.LastName,
                    "Lastname is required");
            }

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new UserException(null, request.Username,
                    "Username is required");
            }

            var hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                Password = hashedPassword
            };

            _userRepository.Insert(user);
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5data);
        }
    }
}
