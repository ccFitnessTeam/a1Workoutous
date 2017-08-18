
class WorkoutController {
    constructor($workout, $exercise, $state) {
        this.exerciseService = $exercise;
        this.getAllExercises();
        this.workoutService = $workout;
        this.input;
        this.state = $state;

        this.workout = {
            name: "",
            userId: 0,
            exercises: []
        };
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
        this.workout.userId = sessionStorage.getItem("userToken");
        console.log(this.workout);
        this.workoutService.add(this.workout).then((res) => {
            this.state.go("userPage");
        });
        this.getAllWorkouts();
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