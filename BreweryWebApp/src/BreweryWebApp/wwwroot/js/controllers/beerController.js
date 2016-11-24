(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('beerController', beerController);

    beerController.$inject = ['$location', 'spinnerService', '$timeout'];

    function beerController($location, spinnerService, $timeout) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'beerController';
        spinnerService.show('MainSpinner');
        activate();

        function activate() {
            $timeout(function () { spinnerService.hide('MainSpinner'); }, 1000);
        }
    }
})();
