(function (app) {
    var service = function ($http, $q, $location) {
        var listPath = '/';
        var selectedGenre = 0;
        var setSelectedGenre = function (genreId) {
            listPath = $location.path();
            selectedGenre = genreId;
        };
        var navigateToList = function () {
            $location.path(listPath).search('genreId', selectedGenre);
        };
        return {
            setSelectedGenre: setSelectedGenre,
            navigateToList: navigateToList
        };
    };
    service.$inject = ['$http', '$q', '$location'];
    app.factory("musicAlbumsNavigationService", service);
})(angular.module("musicAlbumsApp"));