
class WorkoutController {
    constructor($workout, $exercise) {
        this.exerciseService = $exercise;

        this.exerciseService.getAllExercises().then((res) => { this.exercises = res.data; });
        //set service to propery
        this.workoutService = $workout;
        //set prop for getting all workouts
        //this.workouts;
        //assign data via get method
        //this.getAllWorkouts().then((res) => {
        //    this.workouts = res.data;
        //});
        //set prop for single workout
        
        this.workout = {
            name: "",
            exercises: []
        };
    }
    
    getAllWorkouts() {
        this.workoutService.getAll();
    }

    addToWorkOut(exerciseToAdd) {
        this.workout.exercises.push(exerciseToAdd);
        console.log(this.workout.exercises)
    }

    addWorkout() {
        console.log(this.workout);
        this.workoutService.add(this.workout);
    }
}