(function(app) {
    var controller = function($scope, $routeParams, movieDvdsService, movieDvdsLookupService, movieDvdsNavigationService) {
        $scope.selectedGenre = 0;
        if (typeof $routeParams.genreId !== "undefined") {
            $scope.selectedGenre = $routeParams.genreId;
        }
        $scope.search = function() {
            movieDvdsNavigationService.setListUrl($scope.selectedGenre);
            movieDvdsService.getMovieDvds($scope.selectedGenre).then(function (movieDvds) {
                $scope.movieDvds = movieDvds;
            });
        };
        movieDvdsLookupService.getGenres().then(function(genres) {
            $scope.genres = genres;
        });
        $scope.search();
    };
    controller.$inject = ['$scope', '$routeParams', 'movieDvdsService', 'movieDvdsLookupService', 'movieDvdsNavigationService'];
    app.controller("movieDvdsController", controller);
})(angular.module("movieDvdsApp"));