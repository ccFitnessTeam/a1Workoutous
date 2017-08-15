//var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

//class FrontController {

//    constructor($mainService) {
//        this.mainService = $mainService;
//        this.exercises = [
//        { "name": "Bench", "description": "Some Text 1" },
//        { "name": "Squat", "description": "Some Text 2" },
//        { "name": "Deadlift", "description": "Some Text 3" }
//        ];

//        this.current = {};
//    }

//    addExercise(exercise){
//    exercises.push(exercise);
//    current = {};
//    };
//    deleteExercise(exercise){
//    var index = exercises.indexOf(exercise);
//    exercises.splice(index, 1);
//    };
//    editExercise(exercise){
//        current = exercise;
//    };
//    saveChanges(){
//        current = {};
//    };

//}

//FrontController.$inject = ['$uibModalInstance'];



//app.controller("myController", function ($scope) {
//    $scope.exercises = [
//        { "name": "Bench", "description": "Some Text 1" },
//        { "name": "Squat", "description": "Some Text 2" },
        //{ "name": "Deadlift", "description": "Some Text 3" }
//    ];

//    $scope.addExercise = function (exercise) {
//        $scope.exercises.push(exercise);
//        $scope.current = {};
//    };
//    $scope.deleteExercise = function (exercise) {
//        var index = $scope.exercises.indexOf(exercise);
//        $scope.exercises.splice(index, 1);
//    };
//    $scope.editExercise = function (exercise) {
//        $scope.current = exercise;
//    };
//    $scope.saveChanges = function () {
//        $scope.current = {};
//    };
//    $scope.current = {};

//});