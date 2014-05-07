(function (app) {
    var service = function ($http, $q, $location) {
        var listPath = '/';
        var selectedGenre = 0;
        var getAlbums = function (genreId) {
            listPath = $location.path();
            var url = window.musicApp.rootUrl + "api/AlbumsSearchApi";
            if (typeof genreId !== "undefined") {
                url += "?genreId=" + genreId;
                selectedGenre = genreId;
            }
            var deferred = $q.defer();
            $http.get(url).success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        var getGenres = function () {
            var deferred = $q.defer();
            $http.get(window.musicApp.rootUrl + "api/GenreApi", { cache: true }).success(function (data) {
                deferred.resolve(data);
            }).error(function () {
                deferred.reject();
            });
            return deferred.promise;
        };
        var getArtists = function() {
            var deferred = $q.defer();
            $http.get(window.musicApp.rootUrl + "api/ArtistApi", { cache: true }).success(function(data) {
                deferred.resolve(data);
            }).error(function() {
                deferred.reject();
            });
            return deferred.promise;
        };
        var getAlbum = function (id) {
            var url = window.musicApp.rootUrl + "api/AlbumsApi/"+id;
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
        var navigateToList = function() { //TODO: Separate this out as its own service say navigationService
            $location.path(listPath).search('genreId', selectedGenre);
        };
        return {
            getAlbums: getAlbums,
            getGenres: getGenres,
            getArtists: getArtists,
            getAlbum: getAlbum,
            saveAlbum: saveAlbum,
            navigateToList: navigateToList
        };
    };
    app.factory("musicAlbumsService", ['$http', '$q', '$location', service]);
})(angular.module("musicAlbumsApp"));