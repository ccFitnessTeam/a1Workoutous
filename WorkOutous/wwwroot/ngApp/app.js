'use strict';

var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

app.controller("Main", MainController);
app.controller("Login", LoginController);
app.controller("Register", RegisterController);
app.controller("Front", FrontController);


app.service("$mainService", MainService);
app.config(function ($stateProvider, $httpProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state('home', {
            url: '/',
            templateUrl: '/ngApp/templates/home.html',
            controller: MainController,
            controllerAs:"ctrl"
        })
        .state('login', {
            url: '/login',
            templateUrl: '/ngApp/templates/login.html',
            controller: LoginController,
            controllerAs: 'ctrl'
        })
        .state('register', {
            url: '/register',
            templateUrl: '/ngApp/templates/register.html',
            controller: RegisterController,
            controllerAs: 'ctrl'
        })
        .state('front', {
            url: '/front',
            templateUrl: '/ngApp/templates/front.html',
            controller: FrontController,
            controllerAs: 'ctrl'
        })
        .state('notFound', {
            url: '/notFound',
            templateUrl: '/ngApp/views/notFound.html'
        });
    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
});

