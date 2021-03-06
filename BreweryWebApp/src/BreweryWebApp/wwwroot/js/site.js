﻿// Write your Javascript code.
var BreweryApp = angular.module('BreweryApp',
['ui.router', 'ngAnimate', 'stormpath', 'stormpath.templates', 'circle.countdown']);

BreweryApp.run(function ($stormpath) {
    $stormpath.uiRouter({
        loginState: 'login',
        defaultPostLoginState: 'home'
    });
});

BreweryApp.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home',
        {
            url: '/',
            templateUrl: '/templates/homePage.html',
            controller: 'homepageController'
        })
        .state('login',
        {
            url: '/login',
            templateUrl: '/templates/loginPage.html',
            controller: 'loginController'
        })
        .state('allRecipes',
        {
            url: '/recipes',
            templateUrl: '/templates/recipesPage.html',
            controller: 'recipesController'
        })
        .state('recipeDetails',
        {
            url: '/recipeDetails/{id}',
            templateUrl: '/templates/recipeDetailsPage.html',
            controller: 'recipeDetailsController'
        })
        .state('addEditRecipe',
        {
            url: '/addEditRecipe/{id}',
            templateUrl: '/templates/recipeAddEditPage.html',
            controller: 'recipeAddEditController',
            //sp: {
            //    authenticate: true
            //}
        })
        .state('beer',
        {
            url: '/beer',
            templateUrl: '/templates/beerPage.html',
            controller: 'beerController',
            //sp: {
            //    authenticate: true
            //}
        })
        .state('addNewBeer',
        {
            url: '/createNewBeer',
            templateUrl: '/templates/startBeerPage.html',
            controller: 'startBeerController'
            //sp: {
            //    authenticate: true
            //}
        })
        .state('administrator',
        {
            url: '/admin',
            templateUrl: '/templates/adminPage.html',
            controller: 'adminController',
            //sp: {
            //    authenticate: true
            //}
        });
});