using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkOutous.Services;
using WorkOutous.Models;
using WorkOutous.ViewModels;


//
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkOutous.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService _service;
        public UserController(Services.IUserService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public List<AppUser> Get()
        {
            return _service.GetAllUsers();
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public AppUser Find(string userName, string password)
        //{
        //    AppUser data = new AppUser();
        //    data = _service.FindUser(userName, password);
        //    return data;
        //}

        [HttpGet("{id}")]
        public AppUser GetUser(int id)
        {
            var user = _service.GetAUser(id);
            return user;
        }

        // POST api/values


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //[HttpGet]
        //public AppUser GetUser([FromBody]LoginUser user)
        //{
        //    try
        //    {
        //        var AppUser = _service.GetAUser(user.UserName, user.Password);
        //        return AppUser;
        //    }
        //    catch
        //    {
        //        AppUser NoLogin = new AppUser { };
        //        NoLogin.UserName = "failure!";
        //        return NoLogin;
        //    }


        //}
    }
}
