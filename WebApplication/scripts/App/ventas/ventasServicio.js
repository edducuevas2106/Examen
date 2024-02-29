"use strict";
(function () {
    var app = angular.module("mainApp");
    app.service("ventasServicio", function ($resource, $http) {

        this.getFacturasByIdentificacion = function (id) {
            var stringCon = "../api/Directorio/GetById/" + id;
            return $resource(stringCon).query();
        };

        this.create = function (objPersonAdd) {
            var request = $http({
                method: 'POST',
                url: "../api/Ventas/create",
                data: JSON.stringify(objPersonAdd),
                dataType: "json",
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' },
            });
            return request;
        };
    });

}());