(function() {
    'use strict';

    angular
        .module('app')
        .directive('temperatureChart', temperatureChart);

    temperatureChart.$inject = ['$window'];
    
    function temperatureChart ($window) {
        // Usage:
        //     <temperatureChart></temperatureChart>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'EA'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();