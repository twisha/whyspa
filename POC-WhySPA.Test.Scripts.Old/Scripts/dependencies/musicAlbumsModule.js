angular.module("musicAlbumsApp", ['ngRoute', 'ngTable', 'angular-loading-bar'])
    .config([
        'cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
            cfpLoadingBarProvider.includeSpinner = false;
        }
    ]);