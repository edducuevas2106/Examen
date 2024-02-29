"use strict";
(function () {
    var app = angular.module("mainApp");
    app.service("ventasServicio", function ($resource, $http) {

        //this.getFacturasByIdentificacion = function (id) {
        //    var stringCon = "../api/Ventas/GetById/" + id;
        //    return $resource(stringCon).query();
        //};

        this.getFacturasByIdentificacion = function (id) {
            var request = $http({
                method: 'GET',
                url: "../api/Ventas/GetById/" + id,
                dataType: "json",
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' },
                isArray: true,
            });
            return request;
        };

        this.create = function (objFactura) {
            var request = $http({
                method: 'POST',
                url: "../api/Ventas/create",
                data: JSON.stringify(objFactura),
                dataType: "json",
                headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' },
            });
            return request;
        };


    });

}());