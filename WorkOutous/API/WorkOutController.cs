using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkOutous.Models;
using WorkOutous.Services;
using WorkOutous.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkOutous.API
{
    [Route("api/work")]
    public class WorkOutController : Controller
    {
        public IWorkOutService _service;
        public WorkOutController(IWorkOutService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public List<WorkOut> Get()
        {
            return _service.GetAllWorkOuts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public WorkOut Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]WorkOutVM workout)
        {
            if(ModelState.IsValid)
            {
                _service.CreateWorkOut(workout);
            }
            else
            {
                BadRequest();
            }
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
    }
}
