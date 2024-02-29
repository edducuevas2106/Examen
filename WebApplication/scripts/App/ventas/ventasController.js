"use strict";
(function () {
    var app = angular.module("mainApp");
    app.controller("ventasController", function ($scope, ventasServicio, toaster) {
        $scope.objFacturaAdd = {
            idPersona: '',
            monto: '',
            fecha: ''
        }
        $scope.identificacionPersona = 0;

        $scope.initApp = function () {
            const queryString = window.location.search;
            const urlParams = new URLSearchParams(queryString);
            const id = urlParams.get('identificacion')


            console.log(id);
            $scope.GetAllById();
        }

    });

}());