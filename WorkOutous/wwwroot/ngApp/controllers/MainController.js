
//main controller for index

class MainController {
    constructor($http, $mainService) {
        //creating a property
        this.message = "Sup!";
        //setting a service after dependency Injection
        this.http = $http;

        this.stuff;
        //example of http request 
        this.http.get("/api/values").then((res) => { this.stuff = res.data });
        //using main service
        this.users;
        this.main = $mainService;
        this.main.getUsers().then((res) => { this.users = res.data });
    }
}

class LoginController {
    constructor($http) {
        this.message = 'login page';
    }
}

class RegisterController {
    constructor($http) {
        this.message = 'register page';
    }
}