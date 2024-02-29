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
        $scope.message = '';
        $scope.itemPersona = {
            nombre: '',
            aPaterno: '',
            aMaterno: '',
            identificacion: ''
        }
        $scope.objFacturaAdd = {
            idPersona: 0,
            monto: '',
            fecha: ''
        }
        $scope.lstFactura = {}
        $scope.informacionPersona = ''
        $scope.idPersona = 0

        $scope.initApp = function () {
            const queryString = window.location.search;
            const urlParams = new URLSearchParams(queryString);
            $scope.idPersona = urlParams.get('identificacion')
            $scope.GetAllById($scope.idPersona);
        }

        $scope.GetAllById = function (id) {
            const toastLiveExample = document.getElementById('liveToast')
            const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)

            ventasServicio.getFacturasByIdentificacion(id)
                .then(function (resp) {
                    $scope.itemPersona = resp.data.personas
                    $scope.lstFactura = resp.data.facturas
                    $scope.informacionPersona = resp.data.personas.nombre + ' ' + resp.data.personas.aPaterno 

                    $scope.message = 'Se cargaron de forma correcta los resultados'
                    toastBootstrap.show()
                }, function (error) {
                    $scope.message = 'Ocurrio un problema al cargar las facturas del cliente'
                    toastBootstrap.show()
            });
        }

        $scope.addFactura = function () {
            const toastLiveExample = document.getElementById('liveToast')
            const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
            $scope.objFacturaAdd.idPersona = $scope.itemPersona.id;

            if ($scope.objFacturaAdd.monto != 0
                && $scope.objFacturaAdd.fecha != ''
                && $scope.objFacturaAdd.idPersona != 0) {
                ventasServicio.create($scope.objFacturaAdd)
                    .then(function (resp) {
                        console.log(resp)
                        if (resp.data > 0) {

                            $scope.message = 'Se agrego de forma correcta la factura'
                            toastBootstrap.show()
                            $scope.objPersonAdd = {}
                            $scope.GetAllById($scope.idPersona)
                        }
                        else {
                            $scope.message = 'Ocurrio un problema al agregar el registro'
                            toastBootstrap.show()
                            $scope.objPersonAdd = {}
                        }
                    }, function (error) {
                        $scope.message = error.data.ExceptionMessage
                        toastBootstrap.show()
                    });
            }
            else {
                $scope.message = 'Se debe de llenar todos los campos requeridos'
                toastBootstrap.show()
            }
        }
    });

}());