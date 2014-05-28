(function (app) {
    var controller = function ($scope) {
        $scope.groups = [
            {
                title: 'Dynamic Group Header - 1',
                content: 'Dynamic Group Body - 1'
            },
            {
                title: 'Dynamic Group Header - 2',
                content: 'Dynamic Group Body - 2'
            }
        ];
        $scope.status = {
            open: false,
            disabled: false
        };
    };
    controller.$inject = ['$scope'];
    app.controller("angularUIAccordianController", controller);
})(angular.module("angularUIBootstrapExamplesApp"));