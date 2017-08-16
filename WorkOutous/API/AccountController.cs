using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkOutous.Models;
using WorkOutous.ViewModels;
using WorkOutous.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkOutous.API
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public IUserService _service;
        public IWorkOutService _wservice;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        //not in use
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //not in use
        [HttpGet("{id}")]
        public List<WorkOut> Get(int id)
        {
            List<WorkOut> workouts = _wservice.GetWorkoutsByUser(id);
            return workouts;
        }

        //register user / create user in db
        [Route("register")]
        [HttpPost]
        public AppUser Register([FromBody]RegisterUser ruser)
        {
            var user = _service.RegisterUser(ruser);
            return user;
        }
        //auth user 
        [Route("login")]
        [HttpPost]
        public AppUser Login([FromBody]LoginUser luser)
        {
            var user = _service.LogInUser(luser);
            if(user == null)
            {
                BadRequest();
            }
            return user;
            
        }
        //not in use
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //not in use
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
