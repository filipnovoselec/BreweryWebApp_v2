(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location']; 

    function indexController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'indexController';

        activate();

        function activate() { }
    }
})();
