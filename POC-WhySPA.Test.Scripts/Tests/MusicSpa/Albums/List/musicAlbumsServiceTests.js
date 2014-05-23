/// <reference path="../../../../bower_components/jasmine/lib/jasmine-core/jasmine.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/list/musicalbumsservice.js" />
describe("List: The factory musicAlbumsService", function () {
    //declare mocks and test data variables
    var service,
        httpBackend,
        appRootUrl,
        testAlbums,
        testGenreId;
    beforeEach(function () {
        //load angular module
        module('musicAlbumsApp');
        //set up test data
        testAlbums = ['Album1', 'Album2'];
        appRootUrl = 'app';
        window.musicApp = { rootUrl: appRootUrl };
        testGenreId = 2;
        //inject angular dependencies
        inject(function ($httpBackend, musicAlbumsService) {
            service = musicAlbumsService;
            httpBackend = $httpBackend;
        });
    });
    it('should define getAlbums method', function () {
        expect(service.getAlbums).toBeDefined();
    });
    it('should make webapi call to get all albums when getAlbums() is called', function () {
        //Arrange
        httpBackend.when('GET', appRootUrl + "api/AlbumsSearchApi").respond(testAlbums);
        //Act
        service.getAlbums();
        //Assert
        httpBackend.expectGET(appRootUrl + "api/AlbumsSearchApi");
        httpBackend.flush();
    });
    it('should make webapi call to get albums by genreId when getAlbums(genreId) is called', function () {
        httpBackend.when('GET', appRootUrl + "api/AlbumsSearchApi" + "?genreId=" + testGenreId).respond(testAlbums);
        service.getAlbums(testGenreId);
        httpBackend.expectGET(appRootUrl + "api/AlbumsSearchApi" + "?genreId=" + testGenreId);
        httpBackend.flush();
    });
    it('should return albums when getAlbums() is called', function () {
        httpBackend.when('GET', appRootUrl + "api/AlbumsSearchApi").respond(testAlbums);
        service.getAlbums().then(function (albums) {
            expect(albums).toEqual(testAlbums);
        });
    });
});