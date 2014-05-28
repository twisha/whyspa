(function (app) {
    var routeConfig = function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "angularUIBootstrapExamplesController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/AngularUIBootstrapExamples/List"
       }).otherwise({ redirectTo: "/" });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("angularUIBootstrapExamplesApp"));