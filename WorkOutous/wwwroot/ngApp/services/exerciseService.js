
class ExerciseService {
    constructor($http) {
        this.http = $http;
        this.resource = "api/exercise/";

    }

    getAllExercises() {
       return this.http.get(this.resource);
    }

    add(exercise){
        this.http.post(this.resource, exercise);
    }
}