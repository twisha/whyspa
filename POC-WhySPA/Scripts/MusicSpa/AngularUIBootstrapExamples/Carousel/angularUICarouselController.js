(function (app) {
    var controller = function ($scope) {
        $scope.myInterval = 5000; //milliseconds
        $scope.slides = [
            {
                image: 'http://placekitten.com/600/300',
                text: 'More Cats'
            }, {
                image: 'http://placekitten.com/601/300',
                text: 'Extra Kittys'
            }, {
                image: 'http://placekitten.com/602/300',
                text: 'Lots of Felines'
            }
        ];
    };
    controller.$inject = ['$scope'];
    app.controller("angularUICarouselController", controller);
})(angular.module("angularUIBootstrapExamplesApp"));