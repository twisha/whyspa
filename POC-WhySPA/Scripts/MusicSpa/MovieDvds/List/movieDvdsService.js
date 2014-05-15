(function (app) {
    var service = function ($http, $q) {
        var getMovieDvds = function (genreId) {
            var url = window.musicApp.rootUrl + "api/MovieDvdsSearchApi";
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
            getMovieDvds: getMovieDvds
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("movieDvdsService", service);
})(angular.module("movieDvdsApp"));