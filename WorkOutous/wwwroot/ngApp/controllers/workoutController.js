
class WorkoutController {
    constructor($workout, $exercise) {
        this.exerciseService = $exercise;
        this.getAllExercises();
        this.workoutService = $workout;
        this.input;

        this.workout = {
            name: "",
            exercises: []
        };
    }
    
    setWorkOut(workOutName) {
        console.log(this.workout);
        console.log(this.workOutName);
        this.workout.name = this.workOutName;
    }

    getAllExercises() {
        this.exerciseService.getAllExercises().then((res) => { this.exercises = res.data; });
    }

    getAllWorkouts() {
        this.workoutService.getAll();
    }

    addToWorkOut(exerciseToAdd) {
        this.workout.exercises.push(exerciseToAdd);
        console.log(this.workout.exercises);
    }

    addWorkout() {
        console.log(this.workout);
        this.workoutService.add(this.workout);
    }

    doSearch(input) {
        if (input === "") {
            this.getAllExercises();
        } else {
            this.exerciseService.getSomeExercises(input).then((res) => {
                this.exercises = res.data;
                console.log(this.exercises);
            });
        }
    }

    doSearchWorkOut(input) {
        if (input === "") {
            this.getAll();
        } else {
            this.workoutService.getSomeWorkouts(this.workout.name).then((res) => {
                this.workOut = res.data;
            });
        }
    }

}