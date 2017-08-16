using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkOutous.Models;

namespace WorkOutous.Data
{
    public class DataBaseContexts : DbContext
    {
        public DataBaseContexts(DbContextOptions<DataBaseContexts> options): base(options)
        {

        }
        //add model for db migration
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<WorkOutExercise> WorkOutExercises { get; set; }
        public DbSet<UserWorkouts> UserWorkouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkOutExercise>().HasKey(x => new { x.WorkOutId, x.ExerciseId });
            builder.Entity<UserWorkouts>().HasKey(w => new { w.AppUserId, w.WorkoutId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
