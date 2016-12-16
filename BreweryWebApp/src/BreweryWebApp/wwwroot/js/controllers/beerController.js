(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('beerController', beerController);

    beerController.$inject = ['$location', 'spinnerService', '$timeout', '$http', '$scope', '$q'];

    function beerController($location, spinnerService, $timeout, $http, $scope, $q) {
        spinnerService.show("MainSpinner");

        updateData()
            .then(function () {
                spinnerService.hide("MainSpinner");
            });

        function updateData() {
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: "Beer/GetCurrentBeer"
            })
                .success(function (response) {
                    $scope.beer = response;

                    var clock = $('.clock').FlipClock($scope.beer.timeToCompletion, {
                        clockFace: 'DailyCounter',
                        countdown: true,
                        showSeconds: false
                    });

                    $scope.progress = { width: $scope.beer.percentageDone * 100 + '%' };

                    deferred.resolve();
                })
                .error(function (response) {

                });
            return deferred.promise;
        }
    }
})();
