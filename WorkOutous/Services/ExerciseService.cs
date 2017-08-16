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

        public List<Exercise> GetSomeExercises(string input)
        {
            List<Exercise> OutputList = new List<Exercise>();
            var Etable = _repo.Query<Exercise>();
            var Sought =
                      from e in Etable.AsQueryable().Where(x => (x.MuscleGroup.Contains(input)) || (x.Name.Contains(input)))
                      select new
                      {
                          e.ExerciseId,
                          e.MuscleGroup,
                          e.Name
                      };
            foreach (var item in Sought)
            {
                Exercise temp = new Exercise();
                temp.ExerciseId = item.ExerciseId;
                temp.MuscleGroup = item.MuscleGroup;
                temp.Name = item.Name;
                OutputList.Add(temp);
            }
            return OutputList;
        }

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
