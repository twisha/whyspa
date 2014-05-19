(function (app) {
    var controller = function ($scope, $routeParams, $filter, ngTableParams, movieDvdsService, movieDvdsLookupService, movieDvdsNavigationService) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== "undefined") {
            $scope.selectedGenre = $routeParams.genreId;
        }
        movieDvdsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        var movieDvdsSearchResultsPromise = movieDvdsService.getMovieDvds($scope.selectedGenre);
        $scope.tableParams = new ngTableParams({
            page: 1, //Default Page Number
            count: 25 //Default Page Size
        }, {
            getData: function ($defer, params) {
                movieDvdsSearchResultsPromise.then(function (moviedDvds) {
                    // use build-in angular filter
                    var filteredData = params.filter() ? $filter('filter')(moviedDvds, params.filter()) : moviedDvds;
                    params.total(filteredData.length); //set total count
                    var orderedData = params.sorting() ? $filter('orderBy')(filteredData, params.orderBy()) : moviedDvds;
                    //set data for current page
                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                });
            }
        });
        $scope.search = function() {
            movieDvdsNavigationService.setListUrl($scope.selectedGenre);
            movieDvdsSearchResultsPromise = movieDvdsService.getMovieDvds($scope.selectedGenre);
            $scope.tableParams.page(1);
            $scope.tableParams.count(25);
            $scope.tableParams.filter({});
            $scope.tableParams.sorting({});
            $scope.tableParams.reload();
        };
    };
    controller.$inject = ['$scope', '$routeParams', '$filter', 'ngTableParams', 'movieDvdsService', 'movieDvdsLookupService', 'movieDvdsNavigationService'];
    app.controller("movieDvdsController", controller);
})(angular.module("movieDvdsApp"));