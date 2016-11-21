(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeDetailsController', recipeDetailsController);

    recipeDetailsController.$inject = ['$location']; 

    function recipeDetailsController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'recipeDetailsController';

        activate();

        function activate() { }
    }
})();
