(function (app) {
    var routeConfig = function($routeProvider) {
        $routeProvider.when("/", {
            controller: "",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/AngularUIBootstrapExamples/List"
        }).when("/Accordian", {
            controller: "angularUIAccordianController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/AngularUIBootstrapExamples/Accordian"
        }).when("/Modal", {
            controller: "angularUIModalController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/AngularUIBootstrapExamples/Modal"
        }).when("/Carousel", {
            controller: "angularUICarouselController",
            templateUrl: window.musicApp.rootUrl + "MusicSpa/AngularUIBootstrapExamples/Carousel"
        }).otherwise({ redirectTo: "/" });
    };
    routeConfig.$inject = ['$routeProvider'];
    app.config(routeConfig);
})(angular.module("angularUIBootstrapExamplesApp"));