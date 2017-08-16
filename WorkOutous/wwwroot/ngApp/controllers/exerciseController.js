
class ExerciseController{
    constructor($exercise, $state) {
        this.exercises;
        this.$exerciseService = $exercise;
        this.getAll();
        this.state = $state;
    }

    getAll() {
        this.$exerciseService.getAllExercises().then((res) => { this.exercises = res.data; });
    }

    addExercise(exerciseName, muscleGroup) {
        var exerciseToAdd = { name: exerciseName, MuscleGroup: muscleGroup };
        this.$exerciseService.add(exerciseToAdd);
        this.state.go("exercises");
    }
}