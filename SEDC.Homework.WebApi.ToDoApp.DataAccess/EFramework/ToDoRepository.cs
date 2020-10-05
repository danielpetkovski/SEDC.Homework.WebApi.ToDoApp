using SEDC.Homework.WebApi.ToDoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataAccess.EFramework
{
    public class ToDoRepository : IRepository<ToDo>
    {
        private readonly ToDosDbContext _context;

        public ToDoRepository(ToDosDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _context.ToDos;
        }

        public void Insert(ToDo entity)
        {
            _context.ToDos.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(ToDo entity)
        {
            _context.ToDos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ToDo entity)
        {
            _context.ToDos.Update(entity);
            _context.SaveChanges();
        }
    }
}
