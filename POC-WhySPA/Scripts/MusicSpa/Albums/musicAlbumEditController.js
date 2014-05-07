(function (app) {
    var controller = function ($scope, musicAlbumsService, $routeParams) {
       musicAlbumsService.getAlbum($routeParams.id).then(function (album) {
            $scope.album = album;
       });
       musicAlbumsService.getGenres().then(function (genres) {
           $scope.genres = genres;
       });
       musicAlbumsService.getArtists().then(function (artists) {
           $scope.artists = artists;
       });
        $scope.saveAlbum = function() {
            musicAlbumsService.saveAlbum($routeParams.id, $scope.album).then(function() {
                $scope.saveSuccess = true;
            }, function() {
                $scope.saveSuccess = false;
            });
        };
        $scope.navigateToList = function () {
            musicAlbumsService.navigateToList();
        };
    };
    app.controller("musicAlbumEditController", ['$scope', 'musicAlbumsService', '$routeParams', controller]);
})(angular.module("musicAlbumsApp"));