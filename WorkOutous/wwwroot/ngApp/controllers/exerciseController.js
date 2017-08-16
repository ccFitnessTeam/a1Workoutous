
class ExerciseController{
    constructor($exercise, $state, $stateParams) {
        this.exercises;
        this.$exerciseService = $exercise;
        this.getAll();
        this.state = $state;
        this.stateParams = $stateParams;
        

        this.exercises = {
            muscelGroup: "",
            exercise: []
        };
    }

    getAll() {
        this.$exerciseService.getAllExercises().then((res) => { this.exercises = res.data; });
    }

    addToExercise(exerciseName, muscelGroup) {
        var exerciseToAdd = { exercise: exerciseName, MuscelGroup: muscelGroup };
        this.$exerciseService.add(exerciseToAdd);
        this.state.go("exercises");
    }

    //deleteExercise(id) {
    //    this.$exerciseService.removeExercise(id);
    //}

    editExercise(id) {
        var exerciseToEdit = { exercise: exerciseName, MuscelGroup: muscelGroup };
        this.$exerciseService.edit(exerciseToAdd);
        this.state.go("exercises");
    }


}