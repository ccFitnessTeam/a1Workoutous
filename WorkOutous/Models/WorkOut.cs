using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutous.Models
{
    public class WorkOut
    {
        public int WorkOutId { get; set; }
        public string WorkOutName { get; set; }
        public List<WorkOutExercise> WorkOutExercises { get; set; }
    }
}
