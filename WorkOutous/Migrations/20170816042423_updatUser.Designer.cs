using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkOutous.Data;

namespace WorkOutous.Migrations
{
    [DbContext(typeof(DataBaseContexts))]
    [Migration("20170816042423_updatUser")]
    partial class updatUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkOutous.Models.AppUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Administrator");

                    b.Property<string>("Bio");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserImage");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("WorkOutous.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("MuscleGroup");

                    b.Property<string>("Name");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("WorkOutous.Models.UserWorkouts", b =>
                {
                    b.Property<int>("AppUserId");

                    b.Property<int>("WorkoutId");

                    b.HasKey("AppUserId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("UserWorkouts");
                });

            modelBuilder.Entity("WorkOutous.Models.WorkOut", b =>
                {
                    b.Property<int>("WorkOutId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WorkOutName");

                    b.HasKey("WorkOutId");

                    b.ToTable("WorkOuts");
                });

            modelBuilder.Entity("WorkOutous.Models.WorkOutExercise", b =>
                {
                    b.Property<int>("WorkOutId");

                    b.Property<int>("ExerciseId");

                    b.HasKey("WorkOutId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("WorkOutExercises");
                });

            modelBuilder.Entity("WorkOutous.Models.UserWorkouts", b =>
                {
                    b.HasOne("WorkOutous.Models.AppUser", "AppUser")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkOutous.Models.WorkOut", "Workout")
                        .WithMany("UserWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkOutous.Models.WorkOutExercise", b =>
                {
                    b.HasOne("WorkOutous.Models.Exercise", "Exercise")
                        .WithMany("WorkOutExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkOutous.Models.WorkOut", "WorkOut")
                        .WithMany("WorkOutExercises")
                        .HasForeignKey("WorkOutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
