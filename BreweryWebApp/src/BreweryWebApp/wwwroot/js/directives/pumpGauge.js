(function() {
    'use strict';

    angular
        .module('app')
        .directive('pumpGauge', pumpGauge);

    pumpGauge.$inject = ['$window'];
    
    function pumpGauge ($window) {
        // Usage:
        //     <pumpGauge></pumpGauge>
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