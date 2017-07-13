using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}