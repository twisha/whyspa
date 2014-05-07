(function (app) {
    var controller = function ($scope, musicAlbumsService, $routeParams) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== 'undefined') {
            $scope.selectedGenre = $routeParams.genreId;
        }
        $scope.search = function () {
            console.log($scope.selectedGenre);
           musicAlbumsService.getAlbums($scope.selectedGenre).then(function (albums) {
                $scope.albums = albums;
            });
        };
        musicAlbumsService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        $scope.search();
    };
    app.controller("musicAlbumsController", ['$scope', 'musicAlbumsService', '$routeParams', controller]);
})(angular.module("musicAlbumsApp"));