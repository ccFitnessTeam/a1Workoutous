using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutous.Models
{
    public class UserWorkouts
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int WorkoutId { get; set; }
        public WorkOut Workout { get; set; }
    }
}
