(function (app) {
    var service = function ($http, $q) {
        var getMovieDvds = function(genreId) {
                var url = window.musicApp.rootUrl + "api/MovieDvdsSearchApi";
                if (typeof genreId !== "undefined") {
                    url += "?genreId=" + genreId;
                }
                var deferred = $q.defer();
                $http.get(url).success(function(data) {
                    deferred.resolve(data);
                }).error(function() {
                    deferred.reject();
                });
                return deferred.promise;
            },
            getMovieDvd = function(id) {
                var deferred = $q.defer();
                var url = window.musicApp.rootUrl + "api/MovieDvdsApi/" + id;
                $http.get(url).success(function(data) {
                    deferred.resolve(data);
                }).error(function() {
                    deferred.reject();
                });
                return deferred.promise;
            };
        return {
            getMovieDvds: getMovieDvds,
            getMovieDvd: getMovieDvd
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("movieDvdsService", service);
})(angular.module("movieDvdsApp"));