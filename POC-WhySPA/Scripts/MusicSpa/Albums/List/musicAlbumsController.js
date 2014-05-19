(function (app) {
    var controller = function ($scope, $routeParams, ngTableParams, musicAlbumsService, musicAlbumsLookupService, musicAlbumsNavigationService) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== 'undefined') {
            $scope.selectedGenre = $routeParams.genreId;
        }
        musicAlbumsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        $scope.tableParams = new ngTableParams({
            page: 1, //Default Page Number
            count: 10 //Default Page Size
        }, {
            total: 0, //Records are loaded async this default total count to 0
            getData: function ($defer, params) {
                musicAlbumsNavigationService.setListUrl($scope.selectedGenre);
                musicAlbumsService.getAlbums($scope.selectedGenre).then(function (albums) {
                    params.total(albums.length); //set total count
                    $defer.resolve(albums.slice((params.page() - 1) * params.count(), params.page() * params.count())); //set data for current page
                });
            }
        });
        $scope.search = function () {
            $scope.tableParams.page(1);
            $scope.tableParams.count(10);
            $scope.tableParams.reload();
        };
    };
    controller.$inject = ['$scope', '$routeParams', 'ngTableParams', 'musicAlbumsService', 'musicAlbumsLookupService', 'musicAlbumsNavigationService'];
    app.controller("musicAlbumsController", controller);
})(angular.module("musicAlbumsApp"));