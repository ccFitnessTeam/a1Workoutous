﻿using GameSquad.Repositories;
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
