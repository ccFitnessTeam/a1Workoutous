var app = angular.module("WorkOutous", ['ui.router', 'ngResource']);

class LogInModalController {

    constructor($uibModal) {
        this.$uibModal = $uibModal;
    }

    showModal() {
        this.$uibModal.open({
            url: '/modal',
            templateUrl: '/ngApp/templates/home.html',
            controller: 'LogInController',
            controllerAs: 'controller',
            //resolve: {
            //    animalName: () => animalName
            //},
            size: 'sm'
        });
        console.log('show Modal')
        loginValidation();
    }
}

LogInModalController.$inject = ['$uibModal'];

angular.module('WorkOutous').controller('LoginModalController', LogInModalController);

