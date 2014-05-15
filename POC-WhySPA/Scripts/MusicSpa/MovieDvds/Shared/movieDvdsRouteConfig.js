(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "movieDvdsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/List"
        }).when("/:genreId", {
            controller: "movieDvdsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/List"
        }).when("/Edit/:id", {
            controller: "movieDvdEditController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/MovieDvds/Edit"
        });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("movieDvdsApp"));