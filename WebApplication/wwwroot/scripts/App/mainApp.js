"use strict";
(function () {
    var app = angular.module("mainApp", ['ngRoute', 'ngResource', 'ngDialog', 'ngAnimate', 'ngSanitize', 'ui.bootstrap', 'toaster']);

    app.filter("pagination2", function () {
        return function (data, start) {
            if (!data || !data.length) {
                return;
            }
            start = +start;
            return data.slice(start);
        };
    });

    app.filter("pagination", function () {
        return function (data, start) {
            if (!data || !data.length) {
                return;
            }
            start = +start;
            return data.slice(start);
        };
    });


}());