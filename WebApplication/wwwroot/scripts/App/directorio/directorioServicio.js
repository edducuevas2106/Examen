"use strict";
(function () {
    var app = angular.module("mainApp");
    app.service("directorioServicio", function ($resource, $http) {
        this.create = function (objPersonAdd) {
            var request = $http({
                method: 'POST',
                url: "../api/Directorio/create",
                data: JSON.stringify(objPersonAdd),
                dataType: "json",
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' },
            });
            return request;
        };

        this.delete = function (id) {
            var stringCon = "../api/Directorio/delete/" + id;
            return $resource(stringCon).query();
        };

        this.getByIdentificacion = function (id) {
            var stringCon = "../api/Directorio/GetById/" + id;
            return $resource(stringCon).query();
        };

        this.getAll = function () {
            var stringCon = "../api/Directorio/getAll";
            return $resource(stringCon).query();
        };

        this.getPageAll = function (item) {
            var stringCon = "../api/Directorio/getPaged";
            var promise = $http({
                method: "POST",
                url: stringCon,
                data: JSON.stringify(item),
                dataType: "json",
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' },
            });
            return promise;
        };


    });

}());