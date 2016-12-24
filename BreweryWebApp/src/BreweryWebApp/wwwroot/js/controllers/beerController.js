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
                $scope.chartData = createPairs($scope.beer.readTimes, $scope.beer.temperatures);
                $scope.currentTemp = $scope.beer.temperatures.pop();

                Highcharts.stockChart('temperatureChart',
                {
                    chart: {
                        type: "spline",
                    },
                    title: {
                        text: "Temperatura"
                    },
                    xAxis: {
                        title: {
                            text: "Vrijeme"
                        }
                    },
                    yAxis: {
                        title: {
                            text: "Temperatura"
                        }
                    },
                    rangeSelector: {
                        buttons: [
                        {
                            type: "minute",
                            count: 1,
                            text: "1m"
                        }, {
                            type: "minute",
                            count: 30,
                            text: "30m"
                        }, {
                            type: "hour",
                            count: 3,
                            text: "3h"
                        }, {
                            type: "hour",
                            count: 12,
                            text: "12h"
                        }, {
                            type: "day",
                            count: 1,
                            text: "1d"
                        }, {
                            type: "all",
                            text: "Sve"
                        }]
                    },
                    legend: {
                        enabled: false
                    },
                    exporting: {
                        enabled: false
                    },
                    series: [{
                        name: $scope.beer.name,
                        data: $scope.chartData
                    }]
                });

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
                    console.log(response);
                });
            return deferred.promise;
        }

        function createPairs(time, data) {
            var collection = [];
            for (var i = 0; i < data.length; i++) {
                collection.push([new Date(time[i]).getTime(), data[i]]);
            }

            return collection;
        }
    }
})();
