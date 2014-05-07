(function (app) {
    var controller = function ($scope, $routeParams, musicAlbumsService, musicAlbumsLookupService, musicAlbumsNavigationService) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== 'undefined') {
            $scope.selectedGenre = $routeParams.genreId;
        }
        $scope.search = function () {
            musicAlbumsNavigationService.setSelectedGenre($scope.selectedGenre);
            musicAlbumsService.getAlbums($scope.selectedGenre).then(function (albums) {
                $scope.albums = albums;
            });
        };
        musicAlbumsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        $scope.search();
    };
    controller.$inject = ['$scope', '$routeParams', 'musicAlbumsService', 'musicAlbumsLookupService', 'musicAlbumsNavigationService'];
    app.controller("musicAlbumsController", controller);
})(angular.module("musicAlbumsApp"));