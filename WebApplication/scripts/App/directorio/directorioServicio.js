"use strict";
(function () {
    var app = angular.module("mainApp");
    app.service("directorioServicio", function ($resource, $http) {
        this.create = function (item) {
            var request = $http({
                method: 'POST',
                url: "../api/Directorio/create",
                data: JSON.stringify(item),
                dataType: "json",
                isArray: true
            });
            return request;
        };

        this.delete = function (id) {
            var request = $http({
                method: 'DELETE',
                url: "../api/Directorio/delete/",
                data: JSON.stringify(item),
                dataType: "json",
                isArray: true
            });
            return request;
        };

        this.getByIdentificacion = function (id) {
            var stringCon = "../api/Directorio/GetById/" + id;
            return $resource(stringCon).query();
        };

        this.getAll = function () {
            var stringCon = "../api/Directorio/getAll";
            return $resource(stringCon).query();
        };

        this.getPageAll = function (pageInfo) {
            console.log(2)
            var stringCon = "../api/Directorio/getPaged";
            var promise = $http({
                method: "POST",
                url: stringCon,
                data: JSON.stringify(pageInfo),
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' }
            });
            return promise;
        };


    });

}());