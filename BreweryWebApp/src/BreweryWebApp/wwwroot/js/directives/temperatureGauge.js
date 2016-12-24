(function() {
    'use strict';

    angular
        .module('app')
        .directive('temperatureGauge', temperatureGauge);

    temperatureGauge.$inject = ['$window'];
    
    function temperatureGauge ($window) {
        // Usage:
        //     <temperatureGauge></temperatureGauge>
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