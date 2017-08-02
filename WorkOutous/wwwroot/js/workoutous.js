// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("topBtn").style.display = "block";
    } else {
        document.getElementById("topBtn").style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0; // For Chrome, Safari and Opera 
    document.documentElement.scrollTop = 0; // For IE and Firefox
}

// Side nav-bar function
$(document).ready(function () {
    $(".button-collapse").sideNav({
        closeOnClick: true
    });
});




//Input validation
//app.js
function HandleIT() {
    var name = document.getElementById('<%=txtname.ClientID %>').value;
    var address = document.getElementById('<%=txtaddress.ClientID %>').value;
    PageMethods.ProcessIT(usernameExists, passwordExists, onSucess, onError);
    function onSucess(result) {
        alert(result);
    }
    function onError(result) {
        alert('Something wrong.');
    }
}



//front page CRUD 
//var app = angular.module("WorkOutous", []);

app.controller("frontController", function ($scope) {
    $scope.exercises = [
        { "name": "Bench", "description": "Some Text 1" },
        { "name": "Squat", "description": "Some Text 2" },
        { "name": "Deadlift", "description": "Some Text 3" },
        { "name": "bicep curls", "description": "Some Text 4" }
    ];

    $scope.addExercise = function (exercise) {
        $scope.exercises.push(exercise);
        $scope.current = {};
    };
    $scope.deleteExercise = function (exercise) {
        var index = $scope.exercises.indexOf(exercise);
        $scope.exercises.splice(index, 1);
    };
    $scope.editExercise = function (exercise) {
        $scope.current = exercise;
    };
    $scope.saveChanges = function () {
        $scope.current = {};
    };
    $scope.current = {};

});
