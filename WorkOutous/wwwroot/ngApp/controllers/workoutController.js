
class WorkoutController {
    constructor($workout) {
        this.workoutService = $workout;
        this.workouts;
        this.getAllWorkouts().then((res) => {
            this.workouts = res.data;
        });
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