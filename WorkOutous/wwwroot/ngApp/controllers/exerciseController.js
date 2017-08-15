
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

    addExercise(exerciseName, muscelGroup) {
        var exerciseToAdd = { exercise: exerciseName, MuscelGroup: muscelGroup };
        this.$exerciseService.add(exerciseToAdd);
        this.state.go("exercises");
    }
}