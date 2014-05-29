(function (app) {
    var controller = function ($scope, $modal) {
        $scope.open = function (size) {
            $modal.open({
                templateUrl: window.musicApp.rootUrl + '/MusicSpa/AngularUIBootstrapExamples/ModalContent',
                controller: modalInstanceController,
                size: size,
                resolve: {
                    items: function() {
                        return ['10', '20', '30'];
                    }
                }
            });
        };
        var modalInstanceController = function ($scope, $modalInstance, items) {
            $scope.items = items;
            $scope.selected = {
                item: $scope.items[0]
            };
            $scope.ok = function () {
                $modalInstance.close();
            };
            $scope.cancel = function () {
                $modalInstance.dismiss();
            };
        };
    };
    controller.$inject = ['$scope', '$modal'];
    app.controller("angularUIModalController", controller);
})(angular.module("angularUIBootstrapExamplesApp"));