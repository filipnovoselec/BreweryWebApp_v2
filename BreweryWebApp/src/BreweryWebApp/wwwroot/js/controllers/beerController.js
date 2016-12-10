(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('beerController', beerController);

    beerController.$inject = ['$location', 'spinnerService', '$timeout', '$http', '$scope'];

    function beerController($location, spinnerService, $timeout, $http, $scope) {
        spinnerService.show("MainSpinner");

        updateData()
            .then(function() {
                spinnerService.hide("MainSpinner");
            });

        function updateData() {
            $http({
                    method: "GET",
                    url: "Beet/GetCurrentBeer"
                })
                .success(function(response) {
                    $scope.beer = response;
                })
                .error(function(response) {

                });
        }
    }
})();
