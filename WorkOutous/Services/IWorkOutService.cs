using System.Collections.Generic;
using WorkOutous.Models;
using WorkOutous.ViewModels;

namespace WorkOutous.Services
{
    public interface IWorkOutService
    {
        void CreateWorkOut(WorkOutVM wo);
        void DeleteWorkout(int id);
        List<WorkOut> GetAllWorkOuts();
        WorkOut GetById(int id);
        List<WorkOut> GetWorkoutsByUser(int uId);
    }
}