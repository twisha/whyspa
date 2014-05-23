/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsrouteconfig.js" />
describe("Shared: Routes config for module musicAlbumsApp", function() {
    var routeProvider,
        appRootUrl;
    beforeEach(function() {
        module('musicAlbumsApp');
        appRootUrl = 'app';
        window.musicApp = { rootUrl: appRootUrl };
        inject(function($route) {
            routeProvider = $route;
        });
    });
    it("verify mapping for default list route to view and controller", function() {
        var route = routeProvider.routes['/'];
        expect(route.controller).toBe('musicAlbumsController');
        expect(route.templateUrl).toEqual(musicApp.rootUrl + 'MusicSpa/Albums/List');
    });
    it("verify mapping for list by genreId route to view and controller", function() {
        var route = routeProvider.routes['/:genreId'];
        expect(route.controller).toBe('musicAlbumsController');
        expect(route.templateUrl).toEqual(musicApp.rootUrl + 'MusicSpa/Albums/List');
    });
    it("verify mapping for edit route to view and controller", function() {
        var route = routeProvider.routes['/Edit/:id'];
        expect(route.controller).toBe('musicAlbumEditController');
        expect(route.templateUrl).toEqual(musicApp.rootUrl + 'MusicSpa/Albums/Edit');
    });
    it("verify mapping for other not mapped routes to view and controller", function() {
        var route = routeProvider.routes[null];
        expect(route.redirectTo).toEqual('/');
    });
});