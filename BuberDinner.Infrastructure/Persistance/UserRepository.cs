using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }
        
    }
}