﻿var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

class LogInController {
    constructor($mainService) {
        this.message = 'login page';
        this.mainService = $mainService;
        //this.userLoginResource = "/api/user/";
        this.username;
        this.password
        this.IsLoggedIn;
        this.IsAdmin;

    }
    logIn(uname, pass) {
        this.mainService.checkUser(uname, pass);
    }
    

    //loginValidation() {
    //    var usernameExists = document.getElementById("Username").value;
    //    var passwordExists = document.getElementById("Pwd").value;
    //    var userErrorMessage = document.getElementById("userErrMsg");
    //    var pwdErrorMessage = document.getElementById("passErrMsg");
    //    var nameEntered = false;
    //    var passwordEntered = false;
    //    var stuff;

    //    userErrorMessage.innerHTML = '';
    //    pwdErrorMessage.innerHTML = '';

    //    if (usernameExists === "") {
    //        userErrorMessage.innerHTML = 'Please enter a Username.';
    //    } else {
    //        nameEntered = true;
    //    }

    //    if (passwordExists === "") {
    //        pwdErrorMessage.innerHTML = 'Please enter a Password.';
    //    } else {
    //        passwordEntered = true;
    //    }
    //    console.log(usernameExists + passwordExists + "1")
    //    if (nameEntered && passwordEntered) {
    //        this.mainService.checkUser(usernameExists, passwordExists);
    //    }
    //    return;
    //}
}



angular.module('WorkOutous').controller('LoginController', LogInController);