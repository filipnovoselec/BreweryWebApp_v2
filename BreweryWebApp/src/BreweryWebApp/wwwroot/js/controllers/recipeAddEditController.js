(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipeAddEditController', recipeAddEditController);

    recipeAddEditController.$inject = ['$location', '$scope', '$stateParams', 'spinnerService', '$http'];

    function recipeAddEditController($location, $scope, $stateParams, spinnerService, $http) {
        spinnerService.show('MainSpinner');
        getData();

        function getData() {

            var recipeId = $stateParams.id;

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
