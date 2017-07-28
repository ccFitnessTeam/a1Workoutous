using GameSquad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Models;
using WorkOutous.ViewModels;

namespace WorkOutous.Services
{
    /*public class SearchExercisesService : ISearchExercisesService
    {
        IGenericRepository _repo;
        public SearchExercisesService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public Exercises GetExercises(string exercise, string muscle)
        {
            var ExerciseData = _repo.Query<Exercises>().Where(u => u.Exercise containing exercise) or Where(u => u.MuscelGroup containing muscle).ToList();
            return ExerciseData;
        }
    }*/
}
