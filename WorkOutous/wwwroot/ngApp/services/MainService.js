
class MainService {
    constructor($http) {
        this.http = $http;
        this.userResource = "/api/user/";
        this.userLoginResource = "/api/user/";
        this.valuesResource = "/api/values";
    }

    //get all users
    getUsers(){
        return this.http.get(this.userResource);
    }

    loginUser(user, password) {
        this.stuff;
        var address = this.userLoginResource + "getUser/?userName=" + user + "&password=" + password;
        var send = this.http.get(address).then((res) => {
            alert('Welcome Mr.' + res.data.lastName);
            console.log(res.data.lastName);
            LogInController.IsLoggedIn = true;
            LogInController.IsAdmin = res.data.administrator;
            console.log('IsLoggedIn = ' + LogInController.IsLoggedIn);
            console.log('IsAdmin = ' + LogInController.IsAdmin);
        });
        return send;
    }

    checkUser(user, password) {
        var send = this.loginUser(user, password);
        return;
    }
}