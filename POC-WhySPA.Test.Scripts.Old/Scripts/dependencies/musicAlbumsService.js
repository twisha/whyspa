(function (app) {
    var service = function ($http, $q) {
        var getAlbums = function (genreId) {
            var url = window.musicApp.rootUrl + "api/AlbumsSearchApi";
            if (typeof genreId !== "undefined") {
                url += "?genreId=" + genreId;
            }
            var deferred = $q.defer();
            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        return {
            getAlbums: getAlbums
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("musicAlbumsService", service);
})(angular.module("musicAlbumsApp"));