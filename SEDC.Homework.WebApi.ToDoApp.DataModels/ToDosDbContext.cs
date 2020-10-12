using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels
{
   public class ToDosDbContext : DbContext
    {
        public ToDosDbContext(DbContextOptions opt)
            : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USER
            modelBuilder
                .Entity<User>()
                .ToTable("Users")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<User>()
                .Property(p => p.UserName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired();

            
            modelBuilder
                .Entity<ToDo>()
                .ToTable("ToDos")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<ToDo>()
                .Property(p => p.Text)
                .HasMaxLength(100);

            modelBuilder
                .Entity<ToDo>()
                .Property(p => p.Color);

            modelBuilder
                .Entity<ToDo>()
                .HasOne(p => p.User)
                .WithMany(p => p.ToDos)
                .HasForeignKey(p => p.UserId);

            //SUBTASK

            modelBuilder
                .Entity<SubTask>()
                .ToTable("SubTasks")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<SubTask>()
                .Property(p => p.Text)
                .HasMaxLength(100);

            modelBuilder
                .Entity<SubTask>()
                .Property(p => p.Status);

            modelBuilder
                .Entity<SubTask>()
                .HasOne(p => p.ToDo)
                .WithMany(p => p.SubTasks)
                .HasForeignKey(p => p.ToDoId);

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("bob123"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    UserName = "bob007",
                    Password = hashedPassword,
                    FirstName = "Bob",
                    LastName = "Bobsky"
                });

            modelBuilder.Entity<ToDo>()
                .HasData(
                new ToDo()
                {
                    Id = 1,
                    Text = "Create ToDo App",
                    Color = "yellow",
                    UserId = 1
                },
                new ToDo()
                {
                    Id = 2,
                    Text = "Refactor Video rental Store app",
                    Color = "red",
                    UserId = 1
                }
                );

            modelBuilder.Entity<SubTask>()
                .HasData(
                new SubTask()
                {
                    Id = 1,
                    Text = "Research and consult with client",
                    Status = 3,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 2,
                    Text = "Create the application",
                    Status = 2,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 3,
                    Text = "Add swagger",
                    Status = 1,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 4,
                    Text = "Consult with client about changes",
                    Status = 3,
                    ToDoId = 2
                },
                new SubTask()
                {
                    Id = 5,
                    Text = "Make a team meeting",
                    Status = 2,
                    ToDoId = 2
                },
                new SubTask()
                {
                    Id = 6,
                    Text = "Code the app",
                    Status = 1,
                    ToDoId = 2
                }
                );

        }

    }
}
