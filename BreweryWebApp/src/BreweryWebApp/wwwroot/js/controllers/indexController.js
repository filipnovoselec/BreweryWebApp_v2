(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location', '$scope', '$http'];

    function indexController($location, $scope, $http) {
        fetchRecipes();

        function fetchRecipes() {
            $http.get("Recipe/GetAllRecipeNames")
                .success(function (response) {
                    $scope.recipeNames = response;
                })
                .error(function (response) {
                    console.log(response);
                });
        }
    }
})();
