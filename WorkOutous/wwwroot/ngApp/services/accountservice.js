
class AccountService{
    constructor($http) {
        this.loginResource = "/api/account/login/";
        this.registerResource = "/api/account/register/";
        this.resource = "/api/account/";
        this.userResource = "/api/user/";
        this.workoutResource = "/api/Work/GetWorkOutExercises/?woId=";
        this.http = $http;
    }

    login(data) {
        var returnData = this.http.post(this.loginResource, data);
        console.log(returnData);
       return returnData;
    }

    register(data) {
        return this.http.post(this.registerResource, data);
    }

    getWorkOutsById(uid) {
        return this.http.get(this.resource + uid);
    }

    getUser(id) {
        return this.http.get(this.userResource + id);
    }

    getExercisesWorkOutId(woId) {
        return this.http.get(this.workoutResource + woId);
    }
}