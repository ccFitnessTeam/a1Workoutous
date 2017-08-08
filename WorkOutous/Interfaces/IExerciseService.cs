using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IExerciseService
    {
        List<Exercises> GetAll();
        Exercises GetExercise(int id);
        void RemoveExercise(int id);
        void UpdateExercise(Exercises exercise);
    }
}