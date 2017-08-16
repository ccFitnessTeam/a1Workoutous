class DeleteController {
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

    deleteExercise(id) {
        this.$exerciseService.removeExercise(this.id);
        this.state.go("exercises");

    }
}