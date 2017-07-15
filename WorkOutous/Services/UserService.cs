using GameSquad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public class UserService : IUserService
    {
        IGenericRepository _repo;
        public UserService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<User> GetAllUsers()
        {
            var users = _repo.Query<User>().ToList();
            return users;
        }

        public List<User> GetOneUsers()
        {
            var users = _repo.Query<User>().ToList();
            return users;
        }
    }
}
