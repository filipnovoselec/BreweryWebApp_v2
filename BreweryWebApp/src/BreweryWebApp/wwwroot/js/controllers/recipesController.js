(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipesController', recipesController);

    recipesController.$inject = ['$location', 'spinnerService', '$timeout'];

    function recipesController($location, spinnerService, $timeout) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'recipesController';
        spinnerService.show('MainSpinner');
        activate();

        function activate() {
            $timeout(function () { spinnerService.hide('MainSpinner'); }, 300);
        }
    }
})();
