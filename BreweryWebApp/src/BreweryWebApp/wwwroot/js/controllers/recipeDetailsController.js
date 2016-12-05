(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeDetailsController', recipeDetailsController);

    recipeDetailsController.$inject = ['$location', '$scope', 'spinnerService', '$stateParams', '$http', '$state', '$rootScope'];

    function recipeDetailsController($location, $scope, spinnerService, $stateParams, $http, $state, $rootScope) {
        spinnerService.show('MainSpinner');
        getData();

        $scope.editRecipe = function(id) {
            $state.go('addEditRecipe', { id: id });
        };

        $scope.deleteRecipe = function(id) {
            $http({
                    method: "POST",
                    url: "Recipe/DeleteRecipe",
                    params: { id: id }
                })
                .success(function(response) {
                    $rootScope.$emit("refreshNames", {});
                    $state.go("allRecipes");
                })
                .error(function(response) {
                    console.log(response);
                    $state.reload();
                });
        };

        function getData() {

            var recipeId = $stateParams.id;

            $http({
                method: "GET",
                url: "Recipe/GetRecipeForId",
                params: { recipeId: recipeId }
            })
                .success(function (response) {
                    $scope.recipe = response;
                })
                .error(function (response) {
                    console.log(response);
                })
                .then(function () {
                    spinnerService.hide("MainSpinner");
                });
        }
    }
})();
