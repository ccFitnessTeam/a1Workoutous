using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkOutous.Models;
using WorkOutous.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkOutous.API
{
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        IExerciseService _service;
        public ExerciseController(IExerciseService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public List<Exercise> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Exercises/input
        [HttpGet("GetExercises")]
        public List<Exercises> GetExercises(string input)
        {
            List<Exercises> exercisedata = new List<Exercises>();
            exercisedata = _service.GetSomeExercises(input);
            return exercisedata;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Exercise Get(int id)
        {
            return _service.GetExercise(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Exercise exercise)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _service.UpdateExercise(exercise);
                    return "Database row created  succsesfully! " + exercise.ToString();
                }
                else
                {
                    return "Failed! " + exercise.ToString();
                }
            }
            catch
            {
                return "runtime failure";
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           
            try 
            {
                _service.RemoveExercise(id);
                return "Database row deleted  succsesfully!";
            }
            catch
            {
                return "Failed! ";
            }
        }
    }
}
