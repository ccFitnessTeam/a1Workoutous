using GameSquad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;
using WorkOutous.ViewModels;

namespace WorkOutous.Services
{
    public class UserService : IUserService
    {
        IGenericRepository _repo;
        public UserService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<AppUser> GetAllUsers()
        {
            var AppUser = _repo.Query<AppUser>().ToList();
            return AppUser;
        }

        public AppUser GetAUser(string username, string password)
        {
            var user = _repo.Query<AppUser>().Where(u => u.UserName == username).Where(u => u.Password == password).FirstOrDefault();
            return user;
        }
    }
}
