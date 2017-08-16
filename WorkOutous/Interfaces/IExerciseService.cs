using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IExerciseService
    {
        List<Exercise> GetAll();
        Exercise GetExercise(int id);
        void RemoveExercise(int id);
        List<Exercise> GetSomeExercises(string input);
        void UpdateExercise(Exercise exercise);
    }
}