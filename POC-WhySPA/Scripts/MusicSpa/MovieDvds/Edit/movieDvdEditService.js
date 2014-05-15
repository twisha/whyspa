(function (app) {
    var service = function($http, $q) {
        var getMovieDvd = function(id) {
            var deferred = $q.defer();
            var url = window.musicApp.rootUrl + "api/MovieDvdsApi/" + id;
            $http.get(url).success(function(data) {
                deferred.resolve(data);
            }).error(function() {
                deferred.reject();
            });
            return deferred.promise;
        };
        var saveMovieDvd = function(id, movieDvd) {
            var deferred = $q.defer();
            var url = window.musicApp.rootUrl + "api/MovieDvdsApi/" + id;
            $http.put(url, movieDvd).success(function(data) {
                deferred.resolve(data);
            }).error(function() {
                deferred.reject();
            });
            return deferred.promise;
        };
        return {
            getMovieDvd: getMovieDvd,
            saveMovieDvd: saveMovieDvd
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("movieDvdEditService", service);
})(angular.module("movieDvdsApp"));