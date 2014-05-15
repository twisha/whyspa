(function (app) {
    var controller = function ($scope, $routeParams, movieDvdEditService, movieDvdsLookupService, movieDvdsNavigationService) {
        movieDvdEditService.getMovieDvd($routeParams.id).then(function (movieDvd) {
            $scope.movieDvd = movieDvd;
        });
        movieDvdsLookupService.getGenres().then(function (genres) {
            $scope.genres = genres;
        });
        $scope.saveMovieDvd = function () {
            movieDvdEditService.saveMovieDvd($routeParams.id, $scope.movieDvd).then(function () {
                $scope.saveSuccess = true;
            }, function () {
                $scope.saveSuccess = false;
            });
        };
        $scope.navigateToList = function () {
            movieDvdsNavigationService.navigateToList();
        };
    };
    controller.$inject = ['$scope', '$routeParams', 'movieDvdEditService', 'movieDvdsLookupService', 'movieDvdsNavigationService'];
    app.controller("movieDvdEditController", controller);
})(angular.module("movieDvdsApp"));