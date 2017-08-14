
class ExerciseController{
    constructor($exercise) {
        this.exercises;
        this.$exerciseService = $exercise;
        this.getAll();
    }

    getAll() {
        this.$exerciseService.getAllExercises().then((res) => { this.exercises = res.data; });
    }

    addExercise(exerciseName, muscelGroup) {
        var exerciseToAdd = { exercise: exerciseName, MuscelGroup: muscelGroup };
        this.$exerciseService.add(exerciseToAdd);
    }
}