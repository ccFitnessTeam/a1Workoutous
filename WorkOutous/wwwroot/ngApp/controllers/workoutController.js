
class WorkoutController {
    constructor($workout) {
        //set service to propery
        this.workoutService = $workout;
        //set prop for getting all workouts
        this.workouts;
        //assign data via get method
        this.getAllWorkouts().then((res) => {
            this.workouts = res.data;
        });
        //set prop for single workout
        this.workout = {
            name: "",
            exercises: []
        };
    }
    
    getAllWorkouts() {
        this.workoutService.getAll();
    }

    addWorkout() {
        this.workoutService.add(this.workout);
    }
}