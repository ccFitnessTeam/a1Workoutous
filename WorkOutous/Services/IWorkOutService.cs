using System.Collections.Generic;
using WorkOutous.Models;

namespace WorkOutous.Services
{
    public interface IWorkOutService
    {
        void CreateWorkOut(WorkOut wo);
        void DeleteWorkout(int id);
        List<WorkOut> GetAllWorkOuts();
        WorkOut GetById(int id);
    }
}