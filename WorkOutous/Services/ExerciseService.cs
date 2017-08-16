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

        public List<Exercises> GetAll()
        {
            var exs = _repo.Query<Exercises>().ToList();
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
            var ex = _repo.Query<Exercises>().Where(e => e.ExerciseID == id).FirstOrDefault();
            return ex;
        }

        public void UpdateExercise(Exercises exercise)
        {
            if (exercise.ExerciseID == 0)
            {
                _repo.Add(exercise);
            }
            else
                _repo.Update(exercise);
        }

        public void RemoveExercise(int id)
        {
            var ex = GetExercise(id);
            _repo.Delete(ex);
        }
    }
}
