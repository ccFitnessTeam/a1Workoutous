using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutous.Models
{
    public class Wip
    {
        [Key]
        public int WipID { get; set; }
        public int ExerciseID { get; set; }
        public int UserID { get; set; }
    }
}
