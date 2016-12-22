(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('homepageController', controller);

    controller.$inject = ['$location', 'spinnerService', '$timeout', '$scope', '$http', '$q'];

    function controller($location, spinnerService, $timeout, $scope, $http, $q) {
        var vm = this;
        vm.title = 'controller';
        $scope.currentBeer = null;

        updateData()
            .then(function () {
                Highcharts.chart('container',
                    {
                        chart: {
                            type: "pie"
                        },
                        title: false,
                        plotOptions: {
                            pie: {
                                innerSize: "65%",
                                dataLabels: false
                            }
                        },
                        exporting: {
                            enabled: false
                        },
                        series: [
                            {
                                name:"Postotak završen",
                                data:[
                                {
                                    name: "Gotovo",
                                    y: $scope.currentBeer.percentageDone.toFixed(4) * 100,
                                    color: "#66ff33"
                                }, {
                                    name: "Preostalo",
                                    y: (1 - $scope.currentBeer.percentageDone.toFixed(4)) * 100
                                }]
                            }
                        ]
                    });
                spinnerService.hide('MainSpinner');
            });



        function updateData() {
            spinnerService.show('MainSpinner');
            var deferred = $q.defer();
            $scope.previousBeer = null;

            $http({
                method: "GET",
                url: "Beer/GetCurrentBeerMin"
            })
                .success(function (response) {
                    $scope.currentBeer = response;
                    deferred.resolve();
                })
                .error(function (response) {
                    console.log(response);
                });

            return deferred.promise;
        }
    }
})();
