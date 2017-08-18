using GameSquad.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;
using WorkOutous.ViewModels;

namespace WorkOutous.Services
{
    public class WorkOutNames
    {
        public string WorkOutName;
    }

    public class WorkOutService : IWorkOutService
    {
        public IGenericRepository _repo;
        public WorkOutService( IGenericRepository repo)
        {
            _repo = repo;

        }
        //get all workouts
        public List<WorkOut> GetAllWorkOuts()
        {
            return _repo.Query<WorkOut>().ToList();
        }

        public List<WorkOutNames> GetSomeWorkOuts(string input)
        {
            List<WorkOutNames> OutputList = new List<WorkOutNames>();
            var Etable = _repo.Query<WorkOut>();
            var Sought =
                      from e in Etable.AsQueryable().Where(x => (x.WorkOutName.Contains(input)))
                      select new
                      {
                          e.WorkOutName
                      };
            foreach (var item in Sought)
            {
                WorkOutNames temp = new WorkOutNames();
                temp.WorkOutName = item.WorkOutName;
                OutputList.Add(temp);
            }
            return OutputList;
        }
        public WorkOut GetById(int id)
        {
            var workout = _repo.Query<WorkOut>().Where(w => w.WorkOutId == id).Include(w => w.WorkOutExercises).FirstOrDefault();

            foreach (var exercise in workout.WorkOutExercises)
            {
                exercise.WorkOut = null;
            }

            return workout;
        }
        //create or update workout
        public void CreateWorkOut(WorkOutVM wo)
        {
            var workout = new WorkOut
            {
                WorkOutId = wo.Id,
                WorkOutName = wo.Name
            };

            if (workout.WorkOutId == 0)
            {
                _repo.Add(workout);
                var workoutToAdd = new UserWorkouts
                {
                    AppUserId = wo.userId,
                    WorkoutId = workout.WorkOutId
                };
                _repo.Add(workoutToAdd);
            }
            else
            {
                _repo.Update(workout);
            }

            foreach (var exercise in wo.Exercises)
            {
                var we = new WorkOutExercise();
                we.ExerciseId = exercise.ExerciseId;
                we.WorkOutId = workout.WorkOutId;
                _repo.Add(we);
            }
            
            
        }
        //remove workout by id
        public void DeleteWorkout(int id)
        {
            var workout = GetById(id);
            _repo.Delete(workout);
        }
        // get exercises by workout id
        public List<Exercise> GetExercisesByWorkoutId(int woId)
        {
            var woe = _repo.Query<WorkOutExercise>().Where(w => w.WorkOutId == woId).ToList();
            var workoutExercises = new List<Exercise>();
            foreach (var item in woe)
            {
                var exercise = _repo.Query<Exercise>().Where(e => e.ExerciseId == item.ExerciseId).Select(e => new Exercise
                {
                    Name = e.Name,
                    MuscleGroup = e.MuscleGroup
                }).FirstOrDefault();
                workoutExercises.Add(exercise);
            }
            return workoutExercises;
        }

        //get workouts by user id 
        public List<WorkOut> GetWorkoutsByUser(int uId)
        {
            var wos = _repo.Query<UserWorkouts>().Where(u => u.AppUserId == uId).ToList();
            var workouts = new List<WorkOut>();
            foreach (var uw in wos)
            {
                var workout = _repo.Query<WorkOut>().Where(w => w.WorkOutId == uw.WorkoutId).Select(w => new WorkOut {
                    WorkOutId = w.WorkOutId,
                    WorkOutName = w.WorkOutName
                }).FirstOrDefault();
                workouts.Add(workout);
            }

            return workouts;
        }
    }
}
