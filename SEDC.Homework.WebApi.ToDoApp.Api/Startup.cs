using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SEDC.Homework.WebApi.ToDoApp.Services;
using SEDC.Homework.WebApi.ToDoApp.Services.Helpers;
using SEDC.Homework.WebApi.ToDoApp.Services.Interfaces;

namespace SEDC.Homework.WebApi.ToDoApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // getting connection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // registering data access dependencies
            DiModule.RegisterModule(services, connectionString);


            //service registration
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IToDoService, ToDoService>();
            services.AddTransient<ISubTaskService, SubTaskService>();
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
