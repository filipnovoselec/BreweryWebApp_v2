(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeDetailsController', recipeDetailsController);

    recipeDetailsController.$inject = ['$location', '$scope', 'spinnerService', '$stateParams', '$http', '$state'];

    function recipeDetailsController($location, $scope, spinnerService, $stateParams, $http, $state) {
        spinnerService.show('MainSpinner');
        getData();

        $scope.editRecipe = function(id) {
            $state.go('addEditRecipe', { id: id });
        }
        
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
