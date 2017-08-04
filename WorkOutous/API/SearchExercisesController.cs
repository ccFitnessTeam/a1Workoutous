using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkOutous.Data;
using WorkOutous.Models;
using WorkOutous.Services;

namespace WorkOutous.API
{
    [Route("api/[controller]")]
    public class SearchExercisesController : Controller
    {
        ISearchExercisesService _service;

        public SearchExercisesController(ISearchExercisesService service)
        {
            _service = service;
        }

        // GET: api/Exercises
        /*[HttpGet]
        public IEnumerable<Exercises> Exercises()
        {
            return _service.Exercises1();
        } */
        // GET: api/Exercises/input
        [HttpGet("GetExercises")]
        public List<Exercises> GetExercises( string input)
        {
            List<Exercises> exercisedata = new List<Exercises>();
            exercisedata = _service.GetSomeExercises(input);
            return exercisedata;
        }

        [HttpGet("GetWip")]
        public List<WipSet> GetWip(string input)
        {
            List<WipSet> exercisedata = new List<WipSet>();
            exercisedata = _service.GetWip(input);
            return exercisedata;
        }

        /*// GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercises([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercises = await _service.Exercises().SingleOrDefaultAsync(m => m.ExerciseID == id);

            if (exercises == null)
            {
                return NotFound();
            }

            return Ok(exercises);
        }*/

        // PUT: api/Exercises/5
        /*[HttpPut("{id}")]
        public async void PutExercises([FromRoute] int id, [FromBody] Exercises exercises)
        {
        }

        // POST: api/Exercises
        [HttpPost]
        public async void PostExercises([FromBody] Exercises exercises)
        {
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async void DeleteExercises([FromRoute] int id)
        {
        } */
    }
}