﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.Homework.WebApi.ToDoApp.DataModels;

namespace SEDC.Homework.WebApi.ToDoApp.DataModels.Migrations
{
    [DbContext(typeof(ToDosDbContext))]
    partial class ToDosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.Homework.WebApi.ToDoApp.DataModels.SubTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<string>("Text")
                        .HasMaxLength(100);

                    b.Property<int>("ToDoId");

                    b.HasKey("Id");

                    b.HasIndex("ToDoId");

                    b.ToTable("SubTasks");

                    b.HasData(
                        new { Id = 1, Status = 3, Text = "Research and consult with client", ToDoId = 1 },
                        new { Id = 2, Status = 2, Text = "Create the application", ToDoId = 1 },
                        new { Id = 3, Status = 1, Text = "Add swagger", ToDoId = 1 },
                        new { Id = 4, Status = 3, Text = "Consult with client about changes", ToDoId = 2 },
                        new { Id = 5, Status = 2, Text = "Make a team meeting", ToDoId = 2 },
                        new { Id = 6, Status = 1, Text = "Code the app", ToDoId = 2 }
                    );
                });

            modelBuilder.Entity("SEDC.Homework.WebApi.ToDoApp.DataModels.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("Text")
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDos");

                    b.HasData(
                        new { Id = 1, Color = "yellow", Text = "Create ToDo App", UserId = 1 },
                        new { Id = 2, Color = "red", Text = "Refactor Video rental Store app", UserId = 1 }
                    );
                });

            modelBuilder.Entity("SEDC.Homework.WebApi.ToDoApp.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Bob", LastName = "Bobsky", Password = "*??????Q?	??", UserName = "bob007" }
                    );
                });

            modelBuilder.Entity("SEDC.Homework.WebApi.ToDoApp.DataModels.SubTask", b =>
                {
                    b.HasOne("SEDC.Homework.WebApi.ToDoApp.DataModels.ToDo", "ToDo")
                        .WithMany("SubTasks")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SEDC.Homework.WebApi.ToDoApp.DataModels.ToDo", b =>
                {
                    b.HasOne("SEDC.Homework.WebApi.ToDoApp.DataModels.User", "User")
                        .WithMany("ToDos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
