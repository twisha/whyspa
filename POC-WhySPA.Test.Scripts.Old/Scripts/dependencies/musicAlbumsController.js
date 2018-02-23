(function (app) {
    var controller = function ($scope, $routeParams, $filter, ngTableParams, musicAlbumsService, musicAlbumsLookupService, musicAlbumsNavigationService) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== 'undefined') {
            $scope.selectedGenre = $routeParams.genreId;
        }
        musicAlbumsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        var albumsSearchResultsPromise = musicAlbumsService.getAlbums($scope.selectedGenre);
        $scope.tableParams = new ngTableParams({
            page: 1, //Default Page Number
            count: 25 //Default Page Size
        }, {
            getData: function ($defer, params) {
                albumsSearchResultsPromise.then(function (albums) {
                    // use build-in angular filter
                    var filteredData = params.filter() ? $filter('filter')(albums, params.filter()) : albums;
                    params.total(filteredData.length); //set total count
                    var orderedData = params.sorting() ? $filter('orderBy')(filteredData, params.orderBy()) : albums;
                    //set data for current page
                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                });
            }
        });
        $scope.search = function () {
            musicAlbumsNavigationService.setListUrl($scope.selectedGenre);
            albumsSearchResultsPromise = musicAlbumsService.getAlbums($scope.selectedGenre);
            $scope.tableParams.page(1);
            $scope.tableParams.count(25);
            $scope.tableParams.filter({});
            $scope.tableParams.sorting({});
            $scope.tableParams.reload();
        };
    };
    controller.$inject = ['$scope', '$routeParams', '$filter', 'ngTableParams', 'musicAlbumsService', 'musicAlbumsLookupService', 'musicAlbumsNavigationService'];
    app.controller("musicAlbumsController", controller);
})(angular.module("musicAlbumsApp"));