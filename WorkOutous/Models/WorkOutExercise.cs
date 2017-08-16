using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutous.Models
{
    public class WorkOutExercise
    {
        public int WorkOutId { get; set; }
        public WorkOut WorkOut { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
