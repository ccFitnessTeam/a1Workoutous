using GameSquad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public class ExerciseService : IExerciseService
    {
        IGenericRepository _repo;
        public ExerciseService(IGenericRepository repo)
        {
            _repo = repo;
        }
        //get all exercises out of db
        public List<Exercise> GetAll()
        {
            var exs = _repo.Query<Exercise>().ToList();
            return exs;
        }

        //Get one exercise out of db by itid
        public Exercise GetExercise(int id)
        {
            var ex = _repo.Query<Exercise>().Where(e => e.ExerciseId == id).FirstOrDefault();
            return ex;
        }
        //create a row for exercise or pdate row
        public void UpdateExercise(Exercise exercise)
        {
            if (exercise.ExerciseId == 0)
            {
                _repo.Add(exercise);
            }
            else
                _repo.Update(exercise);
        }
        //remove exercise from db by id
        public void RemoveExercise(int id)
        {
            var ex = GetExercise(id);
            _repo.Delete(ex);
        }
    }
}
