(function (app) {
    var service = function ($location) {
        var listUrl = '/';
        var setListUrl = function (genreId) {
            $location.search('genreId', genreId);
            listUrl = $location.url();
        };
        var navigateToList = function () {
            $location.url(listUrl);
        };
        return {
            setListUrl: setListUrl,
            navigateToList: navigateToList
        };
    };
    service.$inject = ['$location'];
    app.factory("musicAlbumsNavigationService", service);
})(angular.module("musicAlbumsApp"));