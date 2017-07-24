using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IUserService
    {
        List<AppUser> GetAllUsers();
        AppUser GetAUser(string userName, string password);
    }
}