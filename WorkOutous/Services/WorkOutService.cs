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
    public class WorkOutService : IWorkOutService
    {
        public IGenericRepository _repo;
        public WorkOutService( IGenericRepository repo)
        {
            _repo = repo;

        }
        
        public List<WorkOut> GetAllWorkOuts()
        {
            return _repo.Query<WorkOut>().ToList();
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
            }
            else
            {
                _repo.Update(workout);
            }

            foreach (var exercise in wo.Exercises)
            {
                var we = new WorkOutExercise();
                we.ExerciseId = exercise.ExerciseID;
                we.WorkOutId = workout.WorkOutId;
                _repo.Add(we);
            }
            
            
        }

        public void DeleteWorkout(int id)
        {
            var workout = GetById(id);
            _repo.Delete(workout);
        }
    }
}
