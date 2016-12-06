(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('startBeerController', startBeerController);

    startBeerController.$inject = ['$location', '$scope', '$state', '$http'];

    function startBeerController($location, $scope, $state, $http) {

        $scope.startBeer = function() {
            var beer = {
                Name: $scope.beer.name,
                StartDate: $scope.beer.startDate,
                EndDate: $scope.beer.endDate
            }

            $http({
                    method: "POST",
                    url: "Beer/CreateNewBeer",
                    data: beer
                })
                .success(function(response) {
                    $state.go('beer');
                })
                .error(function(response) {
                    console.log(response);
                    $state.reload();
                });
        };
    }
})();
