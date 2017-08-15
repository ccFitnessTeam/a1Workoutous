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
        //all users
        public List<AppUser> GetAllUsers()
        {
            var AppUser = _repo.Query<AppUser>().ToList();
            return AppUser;
        }
        public AppUser FindUser(string username, string password)
        {
            return _repo.Query<AppUser>().Where(u => u.UserName == username).Where(u => u.Password == password).FirstOrDefault();
        }
        //user by id
        public AppUser GetAUser(int id)
        {
            var user = _repo.Query<AppUser>().Where(u => u.UserId == id).FirstOrDefault();
            return user;
        }
        //log in user
       public AppUser LogInUser(LoginUser login)
        {
            var user = _repo.Query<AppUser>().Where(u => u.UserName == login.UserName).FirstOrDefault();
            if(user.Password == login.Password)
            {
                return user;
            }
            else
            {
                return new AppUser();
            }
        }
        //register user
        public AppUser RegisterUser(RegisterUser user)
        {
            var userToAdd = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Administrator = false,
                FirstName = user.FirstName,
                LastName = user.LastName,
                
            };
            _repo.Add(userToAdd);
            return GetAUser(userToAdd.UserId);

        }
    }
}
