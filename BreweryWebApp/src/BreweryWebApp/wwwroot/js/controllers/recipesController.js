(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipesController', recipesController);

    recipesController.$inject = ['$location']; 

    function recipesController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'recipesController';

        activate();

        function activate() { }
    }
})();
