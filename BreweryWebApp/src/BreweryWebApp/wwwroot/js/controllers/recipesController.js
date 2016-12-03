(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('recipesController', recipesController);

    recipesController.$inject = ['$location', 'spinnerService', '$timeout', '$http', '$scope'];

    function recipesController($location, spinnerService, $timeout, $http, $scope) {
        spinnerService.show("MainSpinner");
        fetchRecipes();

        function fetchRecipes() {
            $http.get("Recipe/GetAllRecipeNames")
                .success(function (response) {
                    $scope.recipeNames = response;
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
