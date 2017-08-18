
class WorkoutService {
    constructor($http) {
        this.resource = "/api/work/";
        this.http = $http;
        
    }

    getAll() {
        this.http.get(this.resource);
    }

    getSomeWorkouts(input) {
        return this.http.get(this.resource + "GetWorkOuts/?input=" + input);
    }

    getById(id) {
        this.http.get(this.resource + id);
    }

    add(workout) {
       return this.http.post(this.resource, workout);
    }

    remove(id) {
        this.http.delete(this.resource + id);
    }
}