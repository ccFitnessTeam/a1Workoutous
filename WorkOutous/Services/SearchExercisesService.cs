using GameSquad.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOutous.Data;
using WorkOutous.Models;
using WorkOutous.ViewModels;
using System.Data;
using Microsoft.EntityFrameworkCore;

//using System.Data.Linq;
//using System.Data.Entity.dll;

namespace WorkOutous.Services
{
    public class Wip
    {
        public string UserName;
        public string Exercise;
    }
    public class SearchExercisesService : ISearchExercisesService
    {
        IGenericRepository _repo;
        //private DataBaseContexts _context;
        public DataBaseContexts context;

        public SearchExercisesService(IGenericRepository repo)
        {
            _repo = repo;
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
            //method syntax
            //var s = _repo.Query<Exercises>().Where(ex => ex.MuscelGroup.Contains(input) || ex.Exercise.Contains(input)).Select(ex => new
            //{
            //    ex.ExerciseID,
            //    ex.MuscelGroup,
            //    ex.Exercise
            //}).ToList();

            return OutputList;
        }

        public List<WipSet> GetWip(string input)
        {
            List<WipSet> OutputList = new List<WipSet>();
            OutputList = _repo.Wip<WipSet>(input);
            return OutputList;
        }

        public List<Exercises> Exercises1()
        {
            var Exercises = _repo.Query<Exercises>().ToList();
            return Exercises;
        }
    }
}

