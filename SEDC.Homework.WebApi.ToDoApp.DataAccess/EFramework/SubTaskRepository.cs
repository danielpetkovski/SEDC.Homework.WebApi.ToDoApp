using SEDC.Homework.WebApi.ToDoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataAccess.EFramework
{
    public class SubTaskRepository : IRepository<SubTask>
    {
        private readonly ToDosDbContext _context;

        public SubTaskRepository(ToDosDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SubTask> GetAll()
        {
            return _context.SubTasks;
        }

        public void Insert(SubTask entity)
        {
            _context.SubTasks.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(SubTask entity)
        {
            _context.SubTasks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(SubTask entity)
        {
            _context.SubTasks.Update(entity);
            _context.SaveChanges();
        }
    }
}
