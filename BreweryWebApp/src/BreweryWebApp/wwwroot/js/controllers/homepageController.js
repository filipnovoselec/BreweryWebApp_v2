(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('homepageController', controller);

    controller.$inject = ['$location', 'spinnerService', '$timeout', '$scope', '$http'];

    function controller($location, spinnerService, $timeout, $scope, $http) {
        var vm = this;
        vm.title = 'controller';
        $scope.currentBeer = null;
        $scope.options = {
            cutoutPercentage: 70
        };
        updateData();

        Highcharts.chart('container',
            {
                chart: {
                    type: "pie"
                },
                title:false,
                plotOptions: {
                    pie: {
                        center:["50%","50%"],
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: false
                    }
                },
                series: [
                    {
                        name: "Percentage Done",
                        data: [0.3, 0.7],
                        size: "100%",
                        innerSize: "65%"
                    }
                ]
            });





        function updateData() {
            spinnerService.show('MainSpinner');

            $scope.previousBeer = null;

            $http({
                method: "GET",
                url: "Beer/GetCurrentBeerMin"
            })
                .success(function (response) {
                    $scope.currentBeer = response;
                    $scope.progress = [$scope.currentBeer.percentageDone, 1 - $scope.currentBeer.percentageDone];
                })
                .error(function (response) {
                    console.log(response);
                });

            spinnerService.hide('MainSpinner');
        }
    }
})();
