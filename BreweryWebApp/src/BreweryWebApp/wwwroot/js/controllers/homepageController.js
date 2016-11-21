(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('homepageController', controller);

    controller.$inject = ['$location']; 

    function controller($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'controller';

        activate();

        function activate() { }
    }
})();
