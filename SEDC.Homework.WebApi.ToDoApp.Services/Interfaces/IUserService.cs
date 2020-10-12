using SEDC.Homework.WebApi.ToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Interfaces
{
   public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void Register(RegisterModel request);
    }
}
