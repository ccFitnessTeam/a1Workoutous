class EditController {
    constructor($exercise, $state, $stateParams) {
        this.$exerciseService = $exercise;
        this.state = $state;
        this.stateParams = $stateParams;
        this.exercise;
        this.id = this.stateParams["id"]; 
        this.getExercise();

    }

    getExercise() {
        this.$exerciseService.getExerciseById(this.id).then((res) => { this.exercise = res.data; });
        
    }

    addExercise() {
        this.$exerciseService.addToExercise(this.exercise);
        this.state.go("exercises");
    }
}