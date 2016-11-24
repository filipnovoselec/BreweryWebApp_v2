(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('beerController', beerController);

    beerController.$inject = ['$location','spinnerService']; 

    function beerController($location, spinnerService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'beerController';
        spinnerService.hide('MainSpinner');
        activate();

        function activate() { }
    }
})();
