using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IExerciseService
    {
        List<Exercises> GetAll();
        List<Exercises> GetSomeExercises(string input);
        Exercises GetExercise(int id);
        void RemoveExercise(int id);
        void UpdateExercise(Exercises exercise);
    }
}