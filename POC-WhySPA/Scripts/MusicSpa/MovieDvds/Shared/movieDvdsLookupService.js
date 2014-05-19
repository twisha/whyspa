(function(app) {
    var service = function($http, $q) {
        var getGenres = function () {
            var deferred = $q.defer();
            var url = window.musicApp.rootUrl + "api/MovieGenreApi";
            $http.get(url, { cache: true }).success(function (data) {
                data.unshift({ Key: 0, Value: '' });
                deferred.resolve(data);
            }).error(function() {
                deferred.reject();
            });
            return deferred.promise;
        };
        return {
            getGenres: getGenres
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("movieDvdsLookupService", service);
})(angular.module("movieDvdsApp"));