using System.Collections.Generic;
using WorkOutous.Models;
using WorkOutous.ViewModels;

namespace WorkOutous.Services
{
    public interface IUserService
    {
        List<AppUser> GetAllUsers();
        AppUser GetAUser(int id);
        AppUser RegisterUser(RegisterUser user);
        AppUser LogInUser(LoginUser login);
        AppUser FindUser(string username, string password);
    }
}