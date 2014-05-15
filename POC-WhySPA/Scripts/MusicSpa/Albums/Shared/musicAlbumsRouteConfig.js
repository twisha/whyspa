(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "musicAlbumsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/List"
        }).when("/:genreId", {
            controller: "musicAlbumsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/List"
        }).when("/Edit/:id", {
            controller: "musicAlbumEditController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/Edit"
        }).otherwise({ redirectTo: "/" });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("musicAlbumsApp"));