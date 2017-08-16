
class AccountService{
    constructor($http) {
        this.loginResource = "/api/account/login/";
        this.registerResource = "/api/account/register/";
        this.resource = "/api/account/";
        this.http = $http;
    }

    login(data) {
       return this.http.post(this.loginResource, data);
    }

    register(data) {
        return this.http.post(this.registerResource, data);
    }

    getWorkOutsById(uid) {
        return this.http.get(this.resource + uid);
    }
}