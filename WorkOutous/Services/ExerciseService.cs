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

        public List<Exercises> GetSomeExercises(string input)
        {
            List<Exercises> OutputList = new List<Exercises>();
            var Etable = _repo.Query<Exercises>();
            var Sought =
                      from e in Etable.AsQueryable().Where(x => (x.MuscelGroup.Contains(input)) || (x.Exercise.Contains(input)))
                      select new
                      {
                          e.ExerciseID,
                          e.MuscelGroup,
                          e.Exercise
                      };
            foreach (var item in Sought)
            {
                Exercises temp = new Exercises();
                temp.ExerciseID = item.ExerciseID;
                temp.MuscelGroup = item.MuscelGroup;
                temp.Exercise = item.Exercise;
                OutputList.Add(temp);
            }
            return OutputList;
        }

        public Exercises GetExercise(int id)
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
