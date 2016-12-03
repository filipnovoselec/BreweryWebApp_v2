(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeDetailsController', recipeDetailsController);

    recipeDetailsController.$inject = ['$location', '$scope', 'spinnerService', '$stateParams', '$http'];

    function recipeDetailsController($location, $scope, spinnerService, $stateParams, $http) {
        spinnerService.show('MainSpinner');
        getData();
        
        function getData() {

            var recipeId = $stateParams.id;

            $http({
                    method: "GET",
                    url: "Recipe/GetRecipeForId",
                    params: { recipeId: recipeId }
                })
                .success(function(response) {
                    $scope.recipe = response;
                })
                .error(function(response) {
                    console.log(response);
                })
                .then(function() {
                    spinnerService.hide("MainSpinner");
                });
        }
    }
})();
