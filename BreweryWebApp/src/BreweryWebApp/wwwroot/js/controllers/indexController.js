(function () {
    'use strict';

    angular
        .module('BreweryApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location', '$scope', '$http', '$rootScope'];

    function indexController($location, $scope, $http, $rootScope) {
        fetchRecipes();
        $rootScope.$on("refreshNames", function() {
            fetchRecipes();
        })

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
