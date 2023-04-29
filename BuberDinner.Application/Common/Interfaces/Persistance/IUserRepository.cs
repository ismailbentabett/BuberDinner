using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Entities;
namespace BuberDinner.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
     
    }
}