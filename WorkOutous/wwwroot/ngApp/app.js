'use strict';

var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

//controller
app.controller("Main", MainController).controller("Front", FrontController).controller("ProfileController", ProfileController);
app.controller("ExerciseController", ExerciseController).controller("WorkoutController", WorkoutController).controller("AccountController", AccountController);
app.controller("EditExerciseController", EditExerciseController).controller("DeleteExerciseController", DeleteExerciseController);
//services
app.service("$exercise", ExerciseService).service("$workout", WorkoutService);
app.service("$mainService", MainService).service("$account",AccountService);

app.config(function ($stateProvider, $httpProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: '/ngApp/templates/home.html',
            controller: MainController,
            controllerAs:"ctrl"
        })
        .state('login', {
            url: '/login',
            templateUrl: '/ngApp/templates/login.html',
            controller: AccountController,
            controllerAs: 'ctrl'
        })
        .state('register', {
            url: '/register',
            templateUrl: '/ngApp/templates/register.html',
            controller: AccountController,
            controllerAs: 'ctrl'
        })
        .state('addExercise', {
            url: '/addExercise',
            templateUrl: '/ngApp/templates/addExercise.html',
            controller: ExerciseController,
            controllerAs: 'ctrl'
        })
        .state('exercises', {
            url: '/exercises',
            templateUrl: '/ngApp/templates/exercises.html',
            controller: ExerciseController,
            controllerAs: 'ctrl'
        })
        .state('addWorkout', {
            url: '/addWorkout',
            templateUrl: '/ngApp/templates/addWorkout.html',
            controller: WorkoutController,
            controllerAs: 'ctrl'
        })
        .state('userPage', {
            url: '/userPage',
            templateUrl: '/ngApp/templates/userPage.html',
            controller: ProfileController,
            controllerAs: 'ctrl'
        })
        .state('editExercise', {
            url: '/editExercise/:id',
            templateUrl: '/ngApp/templates/editExercise.html',
            controller: EditExerciseController,
            controllerAs: 'ctrl'
        })
        .state('deleteExercise', {
            url: '/deleteExercise/:id',
            templateUrl: '/ngApp/templates/deleteExercise.html',
            controller: DeleteExerciseController,
            controllerAs: 'ctrl'
        })
        .state('landingPage', {
            url: '/',
            templateUrl: '/ngApp/templates/landingPage.html',
            controller: AccountController,
            controllerAs: 'ctrl'
        })
        .state('notFound', {
            url: '/notFound',
            templateUrl: '/ngApp/views/notFound.html'
        });
    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
});

