(function (app) {
    var service = function ($http, $q) {
        var getAlbum = function (id) {
            var url = window.musicApp.rootUrl + "api/AlbumsApi/" + id;
            var deferred = $q.defer();
            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        var saveAlbum = function (id, album) {
            var url = window.musicApp.rootUrl + "api/AlbumsApi/" + id;
            var deferred = $q.defer();
            $http.put(url, album).success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        return {
            getAlbum: getAlbum,
            saveAlbum: saveAlbum,
        };
    };
    service.$inject = ['$http', '$q'];
    app.factory("musicAlbumEditService", service);
})(angular.module("musicAlbumsApp"));