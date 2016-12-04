(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeAddEditController', recipeAddEditController);

    recipeAddEditController.$inject = ['$location', '$scope', '$stateParams', 'spinnerService',
            '$http', '$state', '$rootScope'];

    function recipeAddEditController($location, $scope, $stateParams, spinnerService, $http, $state, $rootScope) {
        
        var recipeId = $stateParams.id;

        if (recipeId !== "0") {
            spinnerService.show('MainSpinner');
            getData(recipeId);
        }

        $scope.saveRecipe = function () {
            var recipe = {
                Id: $scope.recipe.id,
                Name: $scope.recipe.name,
                Profile: $scope.recipe.profile,
                Picture: $scope.recipe.picture,
                Ingredients: $scope.recipe.ingredients,
                Instructions: $scope.recipe.instructions
            }
            if (recipe.Id != null) {
                $http({
                        method: "POST",
                        url: "Recipe/UpdateRecipe",
                        data: recipe
                    })
                    .success(function (response) {
                        $rootScope.$emit("refreshNames", {});
                        $state.go('allRecipes');
                    })
                    .error(function(response) {
                        console.log(response);
                        $state.reload();
                    });
            } else {
                $http({
                    method: "POST",
                    url: "Recipe/AddNewRecipe",
                    data: recipe
                })
                    .success(function (response) {
                        $rootScope.$emit("refreshNames", {});
                        $state.go('allRecipes');
                    })
                    .error(function (response) {
                        console.log(response);
                        $state.reload();
                    });
            }
            
        }

        $scope.cancelRecipe = function () {
            $state.go('allRecipes');
        }

        function getData(recipeId) {

            $http({
                method: "GET",
                url: "Recipe/GetRecipeForId",
                params: { recipeId: recipeId }
            })
                .success(function (response) {
                    $scope.recipe = response;
                    $scope.newRecipe = false;
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
