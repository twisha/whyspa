(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "musicAlbumsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/List",
            reloadOnSearch: false
        }).when("/:genreId", {
            controller: "musicAlbumsController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/List",
            reloadOnSearch: false
        }).when("/Edit/:id", {
            controller: "musicAlbumEditController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/Albums/Edit",
            reloadOnSearch: false
        }).otherwise({ redirectTo: "/" });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("musicAlbumsApp"));