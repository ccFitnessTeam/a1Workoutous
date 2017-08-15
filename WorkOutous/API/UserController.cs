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
        [HttpGet("{userName, password}")]
        public AppUser Find(string userName, string password)
        {
            AppUser data = new AppUser();
            data = _service.FindUser(userName, password);
            return data;
        }

        // POST api/values
        [HttpPost]
        public AppUser Post([FromBody]LoginUser loginUser)
        {
            try
            {
                var user = _service.LogInUser(loginUser);
                if(user.UserName == null || user.UserName == String.Empty)
                {
                    
                    return user;
                }
                else
                {
                    return _service.FindUser(loginUser.UserName, loginUser.Password);
                }
            }
            catch
            {
                BadRequest("runtime err");
            }
            return null;
            
        }

        [Route("api/[controller]/Register")]
        [HttpPost]
        public AppUser Register([FromBody]RegisterUser ruser)
        {
            var user = _service.RegisterUser(ruser);
            return user;
        }

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
