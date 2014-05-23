/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/edit/musicalbumeditcontroller.js" />
describe('Edit: The controller musicAlbumEditController', function () {
    //declare mocks and test data variables
    var createController,
        $scope,
        routeParamsMock,
        musicAlbumEditServiceMock,
        musicAlbumsLookupServiceMock,
        musicAlbumsNavigationServiceMock,
        testGenres,
        testArtists,
        testAlbum;
    beforeEach(function () {
        //load angular module
        module('musicAlbumsApp');
        //create mocks
        musicAlbumsLookupServiceMock = jasmine.createSpyObj('musicAlbumsLookupService', ['getGenres', 'getArtists']);
        musicAlbumEditServiceMock = jasmine.createSpyObj('musicAlbumEditService', ['getAlbum', 'saveAlbum']);
        musicAlbumsNavigationServiceMock = jasmine.createSpyObj('musicAlbumsNavigationService', ['navigateToList']);
        //set up test data
        testAlbum = { "Id": 86, "Title": "Maquinarama", "Artist": { "Key": 109, "Value": "Skank" }, "Price": 8.99, "Genre": { "Key": 1, "Value": "Rock" } };
        routeParamsMock = { id: testAlbum.Id };
        testGenres = ['Genre1', 'Genre2'];
        testArtists = ['Artist1', 'Artist2'];
        //inject angular dependencies
        inject(function ($rootScope, $controller, $q) {
            $scope = $rootScope.$new();
            //set up mocks
            musicAlbumsLookupServiceMock.getGenres.and.returnValue($q.when(testGenres));
            musicAlbumsLookupServiceMock.getArtists.and.returnValue($q.when(testArtists));
            musicAlbumEditServiceMock.getAlbum.and.returnValue($q.when(testAlbum));
            //set createController method
            createController = function () {
                return $controller('musicAlbumEditController', {
                    $scope: $scope,
                    $routeParams: routeParamsMock,
                    musicAlbumEditService: musicAlbumEditServiceMock,
                    musicAlbumsLookupService: musicAlbumsLookupServiceMock,
                    musicAlbumsNavigationService: musicAlbumsNavigationServiceMock
                });
            };
        });
    });
    it('should set album', function () {
        createController();
        $scope.$apply();
        expect(musicAlbumEditServiceMock.getAlbum).toHaveBeenCalledWith(testAlbum.Id);
        expect($scope.album).toEqual(testAlbum);
    });
    it('should set genres for lookup', function () {
        createController();
        $scope.$apply();
        expect(musicAlbumsLookupServiceMock.getGenres).toHaveBeenCalled();
        expect($scope.genres).toEqual(testGenres);
    });
    it('should set artists for lookup', function () {
        createController();
        $scope.$apply();
        expect(musicAlbumsLookupServiceMock.getArtists).toHaveBeenCalled();
        expect($scope.artists).toEqual(testArtists);
    });
    it('should define saveAlbum method()', function () {
        createController();
        expect($scope.saveAlbum).toBeDefined();
    });
    it('should define navigateToList method()', function () {
        createController();
        expect($scope.navigateToList).toBeDefined();
    });
    it('should set success flag to true when album save service call succeeds', function () {
        inject(function ($q) {
            musicAlbumEditServiceMock.getAlbum.and.returnValue($q.when(testAlbum));
            musicAlbumEditServiceMock.saveAlbum.and.returnValue($q.when());

        });
        createController();
        $scope.$apply();
        $scope.saveAlbum();
        $scope.$apply();
        expect(musicAlbumEditServiceMock.saveAlbum).toHaveBeenCalledWith(testAlbum.Id, testAlbum);
        expect($scope.saveSuccess).toBe(true);
    });
    it('should set success flag to false when album save service call fails', function () {
        inject(function ($q) {
            musicAlbumEditServiceMock.getAlbum.and.returnValue($q.when(testAlbum));
            musicAlbumEditServiceMock.saveAlbum.and.returnValue($q.reject());
        });
        createController();
        $scope.$apply();
        $scope.saveAlbum();
        $scope.$apply();
        expect(musicAlbumEditServiceMock.saveAlbum).toHaveBeenCalledWith(testAlbum.Id, testAlbum);
        expect($scope.saveSuccess).toBe(false);
    });
    it('should call navigation service when navigateToList() is called', function () {
        createController();
        $scope.navigateToList();
        expect(musicAlbumsNavigationServiceMock.navigateToList).toHaveBeenCalled();
    });
});