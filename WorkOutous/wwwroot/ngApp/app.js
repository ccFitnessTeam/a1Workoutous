'use strict';

var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

app.controller("Main", MainController);
app.service("$mainService", MainService);
app.config(function ($stateProvider, $httpProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state('home', {
        url: '/',
        templateUrl: 'ngApp/templates/home.html',
        controller: MainController,
        controllerAs:"ctrl"
        })
        .state('notFound', {
        url: '/notFound',
        templateUrl: '/ngApp/views/notFound.html'
        });
    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
});
