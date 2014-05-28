/// <reference path="../../../../../poc-whyspa/scripts/angular.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-route.js" />
/// <reference path="../../../../../poc-whyspa/bower_components/ng-table/ng-table.js" />
/// <reference path="../../../../../poc-whyspa/scripts/angular-mocks.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/shared/musicalbumsmodule.js" />
/// <reference path="../../../../../poc-whyspa/scripts/musicspa/albums/list/musicalbumscontroller.js" />
describe('List: The controller musicAlbumsController', function () {
    //declare mocks and test data variables
    var controller, $scope,
        routeParamsMock,
        musicAlbumsServiceMock,
        musicAlbumsLookupServiceMock,
        musicAlbumsNavigationServiceMock,
        defaultGenre,
        testGenres,
        testAlbums;
    beforeEach(function () {
        //load angular module (angular.mock.module)
        module('musicAlbumsApp');
        //create mocks
        musicAlbumsLookupServiceMock = jasmine.createSpyObj('musicAlbumsLookupService', ['getGenres']);
        musicAlbumsServiceMock = jasmine.createSpyObj('musicAlbumsService', ['getAlbums']);
        musicAlbumsNavigationServiceMock = jasmine.createSpyObj('musicAlbumsNavigationService', ['setListUrl']);
        //set up test data
        routeParamsMock = {};
        defaultGenre = 0;
        testGenres = ['Genre1', 'Genre2'];
        testAlbums = ['Album1', 'Album2'];
        //inject angular dependencies (angular.mock.inject)
        inject(function ($rootScope, $controller, $q, $filter, ngTableParams) {
            $scope = $rootScope.$new();
            //set up mocks
            musicAlbumsLookupServiceMock.getGenres.and.returnValue($q.when(testGenres));
            musicAlbumsServiceMock.getAlbums.and.returnValue($q.when(testAlbums));
            //create controller
            controller = $controller('musicAlbumsController', {
                $scope: $scope,
                $routeParams: routeParamsMock,
                $filter: $filter,
                ngTableParams: ngTableParams,
                musicAlbumsService: musicAlbumsServiceMock,
                musicAlbumsLookupService: musicAlbumsLookupServiceMock,
                musicAlbumsNavigationService: musicAlbumsNavigationServiceMock
            });
            $scope.$apply();
        });
    });
    it('should set selected genre', function () {
        expect($scope.selectedGenre).toEqual(defaultGenre);
    });

    it('should set genres for lookup', function () {
        expect(musicAlbumsLookupServiceMock.getGenres).toHaveBeenCalled();
        expect($scope.genres).toEqual(testGenres);
    });
    it('should set albums of all genres', function () {
        expect(musicAlbumsServiceMock.getAlbums).toHaveBeenCalledWith(defaultGenre);
    });
    it('should set table parameters', function () {
        expect($scope.tableParams).toBeDefined();
    });
    it('should set albums by genre, reload table and update the url when search() is called', function () {
        $scope.search();
        expect(musicAlbumsNavigationServiceMock.setListUrl).toHaveBeenCalledWith($scope.selectedGenre);
        expect(musicAlbumsServiceMock.getAlbums).toHaveBeenCalledWith($scope.selectedGenre);
        expect($scope.tableParams.page()).toEqual(1);
        expect($scope.tableParams.count()).toEqual(25);
        expect($scope.tableParams.filter()).toEqual({});
        expect($scope.tableParams.sorting()).toEqual({});
    });
});
