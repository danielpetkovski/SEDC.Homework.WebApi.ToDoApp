using SEDC.Homework.WebApi.ToDoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Homework.WebApi.ToDoApp.DataAccess.EFramework
{
    public class UserRepository : IRepository<User>
    {
        private readonly ToDosDbContext _context;

        public UserRepository(ToDosDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
