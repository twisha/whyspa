/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsnavigationservice.js" />
describe("Shared: The factory musicAlbumsNavigationService", function () {
    var service, locationMock;
    beforeEach(function () {
        //load angular module
        module('musicAlbumsApp', function($provide) {
            locationMock = jasmine.createSpyObj('$location', ['search', 'url']);
            $provide.value('$location', locationMock);
        });
        //inject angular dependencies
        inject(function (musicAlbumsNavigationService) {
            service = musicAlbumsNavigationService;
        });
    });
    it("should define setListUrl method", function() {
        expect(service.setListUrl).toBeDefined();
    });
    it("should define navigateToList method", function () {
        expect(service.navigateToList).toBeDefined();
    });
    it("should call $location.search & $location.url when setListUrl() is called", function () {
        var genreId = 2;
        service.setListUrl(genreId);
        expect(locationMock.search).toHaveBeenCalledWith('genreId', genreId);
        expect(locationMock.url).toHaveBeenCalled();
    });
    it("should call $location.url when navigateToList() is called", function() {
        service.navigateToList();
        expect(locationMock.url).toHaveBeenCalledWith('/');
    });
});