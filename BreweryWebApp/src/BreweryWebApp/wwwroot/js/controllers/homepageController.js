(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('homepageController', controller);

    controller.$inject = ['$location','spinnerService','$timeout']; 

    function controller($location,spinnerService,$timeout) {
        var vm = this;
        vm.title = 'controller';
        
        updateData();

        function updateData() {
            spinnerService.show('MainSpinner');

            //todo get data

            $timeout(function () { spinnerService.hide('MainSpinner'); }, 1000);
        }
    }
})();
