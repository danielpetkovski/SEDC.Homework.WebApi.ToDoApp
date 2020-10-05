using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Homework.WebApi.ToDoApp.DataAccess;
using SEDC.Homework.WebApi.ToDoApp.DataAccess.EFramework;
using SEDC.Homework.WebApi.ToDoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.Services.Helpers
{
   public static class DiModule
    {
        public static IServiceCollection RegisterModule(
            IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ToDosDbContext>(
                x => x.UseSqlServer(connectionString));


            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<ToDo>, ToDoRepository>();
            services.AddTransient<IRepository<SubTask>, SubTaskRepository>();

            return services;
        }
    }
}
