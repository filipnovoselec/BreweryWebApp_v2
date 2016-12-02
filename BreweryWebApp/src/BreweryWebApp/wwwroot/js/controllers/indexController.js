(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location','$scope']; 

    function indexController($location, $scope) {
        fetchRecipes();

        function fetchRecipes() {
            //todo fetch recipes form recipes Controller
        }
    }
})();
