
class WorkoutService {
    constructor($http) {
        this.resource = "/api/work/";
        this.http = $http;
        
    }

    getAll() {
        this.http.get(this.resource);
    }

    getById(id) {
        this.http.get(this.resource + id)
    }

    add(workout) {
        this.http.post(workout);
    }

    remove(id) {
        this.http.delete(this.resource + id)
    }
}