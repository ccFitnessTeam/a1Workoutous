using GameSquad.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;

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

        public void CreateWorkOut(WorkOut wo)
        {
            if(wo.WorkOutId == 0)
            {
                _repo.Add(wo);
            }
            else
            {
                _repo.Update(wo);
            }
        }

        public void DeleteWorkout(int id)
        {
            var workout = GetById(id);
            _repo.Delete(workout);
        }
    }
}
