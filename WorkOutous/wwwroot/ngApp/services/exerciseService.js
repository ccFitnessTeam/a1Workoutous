
class ExerciseService {
    constructor($http) {
        this.http = $http;
        this.resource = "api/exercise/";

    }

    getAllExercises() {
       return this.http.get(this.resource);
    }

    addToExercise(exercise){
        this.http.post(this.resource, exercise );
    }

    removeExercise(id) {
        this.http.delete(this.resource + id);
    }

    getExerciseById(id) {
        return this.http.get(this.resource + id);
    }


}