﻿// Write your Javascript code.
var BreweryApp = angular.module('BreweryApp',
['ui.router', 'ngAnimate', 'ngRoute', 'chart.js', 'stormpath', 'stormpath.templates']);

BreweryApp.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home',
        {
            url: '/',
            templateUrl: '~/templates/homePage.html',
            controller: 'homepageController'
        })
        .state('login',
        {
            url: '/login',
            templateUrl: '~/templates/loginPage.html',
            controller: 'loginController'
        })
        .state('recipe',
        {
            url: '/recipe/{name}',
            templateUrl: '~/templates/recipeDetailsPage.html',
            controller: 'recipeController'
        })
        .state('beer',
        {
            url: '/beer',
            templateUrl: '~/templates/beerPage.html',
            controller: 'beerController'
        });
})