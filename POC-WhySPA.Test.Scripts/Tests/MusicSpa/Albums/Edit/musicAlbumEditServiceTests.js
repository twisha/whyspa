/// <reference path="../../../../bower_components/jasmine/lib/jasmine-core/jasmine.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/edit/musicalbumeditservice.js" />
describe("Edit: The factory musicAlbumEditService", function () {
    //declare mocks and test data variables
    var service,
        httpBackend,
        appRootUrl,
        testAlbum;
    beforeEach(function () {
        //load angular module
        module('musicAlbumsApp');
        //set up test data
        testAlbum = { "Id": 86, "Title": "Maquinarama", "Artist": { "Key": 109, "Value": "Skank" }, "Price": 8.99, "Genre": { "Key": 1, "Value": "Rock" } };
        appRootUrl = 'app';
        window.musicApp = { rootUrl: appRootUrl };
        //inject angular dependencies
        inject(function ($httpBackend, musicAlbumEditService) {
            service = musicAlbumEditService;
            httpBackend = $httpBackend;
        });
    });
    it('should define getAlbum method', function () {
        expect(service.getAlbum).toBeDefined();
    });
    it('should define saveAlbum method', function () {
        expect(service.saveAlbum).toBeDefined();
    });
    it('should make webapi call to get album by id when getAlbum(id) is called', function () {
        //Arrange
        httpBackend.when('GET', appRootUrl + "api/AlbumsApi/" + testAlbum.Id).respond(testAlbum);
        //Act
        service.getAlbum(testAlbum.Id);
        //Assert
        httpBackend.expectGET(appRootUrl + "api/AlbumsApi/" + testAlbum.Id);
        httpBackend.flush();
    });
    it('should return album when getAlbum(id) is called', function() {
        //Arrange
        httpBackend.when('GET', appRootUrl + "api/AlbumsApi/" + testAlbum.Id).respond(testAlbum);
        //Act
        service.getAlbum(testAlbum.Id).then(function(album) {
            //Assert
            expect(album).toEqual(testAlbum);
        });
    });
    it('should make webapi call to save album when saveAlbum(id, album) is called', function() {
        //Arrange
        httpBackend.when('PUT', appRootUrl + "api/AlbumsApi/" + testAlbum.Id, testAlbum).respond(204);
        //Act
        service.saveAlbum(testAlbum.Id, testAlbum);
        //Assert
        httpBackend.expectPUT(appRootUrl + "api/AlbumsApi/" + testAlbum.Id, testAlbum).respond(204);
        httpBackend.flush();
    });
});