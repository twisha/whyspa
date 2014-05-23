/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumslookupservice.js" />
describe("Shared: The factory musicAlbumsLookupService", function() {
    //declare mocks and test data variables
    var service,
        httpBackend,
        appRootUrl,
        testGenres,
        testArtists;
    beforeEach(function() {
        //load angular module
        module('musicAlbumsApp');
        //set up test data
        testGenres = ['Genre1', 'Genre2'];
        testArtists = ['Artist1', 'Artist2'];
        appRootUrl = 'app';
        window.musicApp = { rootUrl: appRootUrl };
        //inject angular dependencies
        inject(function($httpBackend, musicAlbumsLookupService) {
            service = musicAlbumsLookupService;
            httpBackend = $httpBackend;
        });
    });
    it('should define getArtists method', function() {
        expect(service.getArtists).toBeDefined();
    });
    it('should define getGenres method', function() {
        expect(service.getGenres).toBeDefined();
    });
    it('should make webapi call to get all genres when getGenres() is called', function() {
        httpBackend.when('GET', appRootUrl + "api/GenreApi").respond(testGenres);
        service.getGenres();
        httpBackend.expectGET(appRootUrl + "api/GenreApi");
        httpBackend.flush();
    });
    it('should return genres when getGenres() is called', function() {
        httpBackend.when('GET', appRootUrl + "api/GenreApi").respond(testGenres);
        service.getGenres().then(function(genres) {
            expect(genres).toEqual(testGenres);
        });
    });
    it('should make webapi call to get all artists when getArtists() is called', function() {
        httpBackend.when('GET', appRootUrl + "api/ArtistApi").respond(testArtists);
        service.getArtists();
        httpBackend.expectGET(appRootUrl + "api/ArtistApi");
        httpBackend.flush();
    });
    it('should return artists when getArtists() is called', function() {
        httpBackend.when('GET', appRootUrl + "api/ArtistApi").respond(testArtists);
        service.getArtists().then(function(artists) {
            expect(artists).toEqual(testArtists());
        });
    });
});