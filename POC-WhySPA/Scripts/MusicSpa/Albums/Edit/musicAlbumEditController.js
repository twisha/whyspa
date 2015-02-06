(function (app) {
    var controller = function ($scope, $routeParams, musicAlbumEditService, musicAlbumsLookupService, musicAlbumsNavigationService) {
        musicAlbumEditService.getAlbum($routeParams.id).then(function (album) {
            $scope.album = album;
        });
        musicAlbumsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        musicAlbumsLookupService.getArtists().then(function (artists) {
            $scope.artists = artists;
        });
        $scope.saveAlbum = function () {
            musicAlbumEditService.saveAlbum($routeParams.id, $scope.album).then(function () {
                $scope.saveSuccess = true;
            }, function () {
                $scope.saveSuccess = false;
            });
        };
        $scope.addAlbum = function () {
            musicAlbumEditService.addAlbum($scope.album).then(function () {
                $scope.saveSuccess = true;
            }, function () {
                $scope.saveSuccess = false;
            });
        };
        $scope.navigateToList = function () {
            musicAlbumsNavigationService.navigateToList();
        };
    };
    controller.$inject = ['$scope', '$routeParams', 'musicAlbumEditService', 'musicAlbumsLookupService', 'musicAlbumsNavigationService'];
    app.controller("musicAlbumEditController", controller);
})(angular.module("musicAlbumsApp"));