(function (app) {
    var service = function ($http, $q) {
        var getGenres = function () {
            var deferred = $q.defer();
            $http.get(window.musicApp.rootUrl + "api/GenreApi", { cache: true }).success(function (data) {
                data.unshift({ Key: 0, Value: '' });
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        var getArtists = function () {
            var deferred = $q.defer();
            $http.get(window.musicApp.rootUrl + "api/ArtistApi", { cache: true }).success(function (data) {
                data.unshift({ Key: 0, Value: '' });
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        return {
            getArtists: getArtists,
            getGenres: getGenres
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("musicAlbumsLookupService", service);
})(angular.module("musicAlbumsApp"));