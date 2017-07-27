using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutous.Models
{
    public class Exercises
    {
        [Key]
        public int ExerciseID { get; set; }
        public string MuscelGroup { get; set; }
        public string Exercise { get; set; }
    }
}
