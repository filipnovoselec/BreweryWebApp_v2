(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('loginController', loginController);

    loginController.$inject = ['$location']; 

    function loginController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'loginController';

        activate();

        function activate() { }
    }
})();
