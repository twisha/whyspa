(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "musicAlbumsController",
            templateUrl: "/MusicSpa/Albums/List"
        }).when("/:genreId", {
            controller: "musicAlbumsController",
            templateUrl: "/MusicSpa/Albums/List"
        }).when("/Edit/:id", {
            controller: "musicAlbumEditController",
            templateUrl: "/MusicSpa/Albums/Edit"
        }).otherwise({ redirectTo: "/" });
    };
    app.config(routeConfig);
})(angular.module("musicAlbumsApp"));