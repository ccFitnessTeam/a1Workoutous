using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkOutous.Migrations
{
    public partial class userToworkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOutExercise_Exercises_ExerciseId",
                table: "WorkOutExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOutExercise_WorkOuts_WorkOutId",
                table: "WorkOutExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOutExercise",
                table: "WorkOutExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "WorkOutExercise",
                newName: "WorkOutExercises");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "AppUsers");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOutExercise_ExerciseId",
                table: "WorkOutExercises",
                newName: "IX_WorkOutExercises_ExerciseId");

            migrationBuilder.RenameColumn(
                name: "ExerciseID",
                table: "Exercises",
                newName: "ExerciseId");

            migrationBuilder.RenameColumn(
                name: "MuscelGroup",
                table: "Exercises",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Exercise",
                table: "Exercises",
                newName: "MuscleGroup");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOutExercises",
                table: "WorkOutExercises",
                columns: new[] { "WorkOutId", "ExerciseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "UserWorkouts",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkouts", x => new { x.AppUserId, x.WorkoutId });
                    table.ForeignKey(
                        name: "FK_UserWorkouts_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkouts_WorkOuts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "WorkOuts",
                        principalColumn: "WorkOutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_WorkoutId",
                table: "UserWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOutExercises_Exercises_ExerciseId",
                table: "WorkOutExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOutExercises_WorkOuts_WorkOutId",
                table: "WorkOutExercises",
                column: "WorkOutId",
                principalTable: "WorkOuts",
                principalColumn: "WorkOutId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOutExercises_Exercises_ExerciseId",
                table: "WorkOutExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOutExercises_WorkOuts_WorkOutId",
                table: "WorkOutExercises");

            migrationBuilder.DropTable(
                name: "UserWorkouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOutExercises",
                table: "WorkOutExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "WorkOutExercises",
                newName: "WorkOutExercise");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOutExercises_ExerciseId",
                table: "WorkOutExercise",
                newName: "IX_WorkOutExercise_ExerciseId");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Exercises",
                newName: "ExerciseID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exercises",
                newName: "MuscelGroup");

            migrationBuilder.RenameColumn(
                name: "MuscleGroup",
                table: "Exercises",
                newName: "Exercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOutExercise",
                table: "WorkOutExercise",
                columns: new[] { "WorkOutId", "ExerciseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOutExercise_Exercises_ExerciseId",
                table: "WorkOutExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOutExercise_WorkOuts_WorkOutId",
                table: "WorkOutExercise",
                column: "WorkOutId",
                principalTable: "WorkOuts",
                principalColumn: "WorkOutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
