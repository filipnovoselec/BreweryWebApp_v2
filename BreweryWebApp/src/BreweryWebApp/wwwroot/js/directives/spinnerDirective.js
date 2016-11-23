(function() {
    'use strict';

    angular
        .module('app')
        .directive('spinnerDirective', spinnerDirective);

    spinnerDirective.$inject = ['$window'];
    
    function spinnerDirective ($window) {
        // Usage:
        //     <spinnerDirective></spinnerDirective>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'EA',
            replace: true,
            template: '/templates/spinnerTemplate.html'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();