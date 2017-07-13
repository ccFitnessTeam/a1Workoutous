
class MainService {
    constructor($http) {
        this.http = $http;
        this.userResource = "/api/user";
    }

    //get all users
    getUsers(){
        return this.http.get(this.userResource);
    }
}