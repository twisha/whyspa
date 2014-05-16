(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "movieDvdsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/List",
            reloadOnSearch: false
        }).when("/:genreId", {
            controller: "movieDvdsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/List",
            reloadOnSearch: false
        }).when("/Edit/:id", {
            controller: "movieDvdEditController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/Edit",
            reloadOnSearch: false
        });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("movieDvdsApp"));