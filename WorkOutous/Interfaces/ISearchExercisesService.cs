using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface ISearchExercisesService
    {
         List<Exercises> GetSomeExercises(string input);
         List<WipSet> GetWip(string input);
        //List<Exercises> Exercises1();
        //Exercises Exercises(int id);

    }
}