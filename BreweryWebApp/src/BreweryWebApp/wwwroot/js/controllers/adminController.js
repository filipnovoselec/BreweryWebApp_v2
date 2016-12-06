(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('adminController', adminController);

    adminController.$inject = ['$location','$scope','$state']; 

    function adminController($location, $scope, $state) {
        
        $scope.startNewBeer = function() {
            $state.go('addNewBeer');
        }
    }
})();
