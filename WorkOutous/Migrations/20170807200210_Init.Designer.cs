using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkOutous.Data;

namespace WorkOutous.Migrations
{
    [DbContext(typeof(DataBaseContexts))]
    [Migration("20170807200210_Init")]
    partial class Init
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

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("WorkOutous.Models.Exercises", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Exercise");

                    b.Property<string>("MuscelGroup");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercises");
                });
        }
    }
}
