"use strict";
(function () {
    var app = angular.module("mainApp");
    app.controller("directorioController", function ($scope, directorioServicio, toaster) {
        $scope.pageSides = [5, 10, 25, 50];
        $scope.pageList = {
            firstItemOnPage: 0,
            hasNextPage: false,
            hasPreviousPage: false,
            isFirstPage: true,
            isLastPage: true,
            lastItemOnPage: 0,
            pageCount: 0,
            pageNumber: 0,
            pageSize: 0,
            totalItemCount: 0
        };

        $scope.pageInfo = {
            pageNumber: 1,
            pageSize: 10,
            search: '',
        };
        $scope.objResult =  {}

        $scope.objPersonAdd = {
            nombre: '',
            aPaterno: '',
            aMaterno: '',
            identificacion: ''
        }
        $scope.objFacturaAdd = {
            idPersona: '',
            monto: '',
            fecha: ''
        }
        $scope.message = ''

        $scope.initApp = function () {
            $scope.GetPaged();
        }

        $scope.GetPaged = function () {
            directorioServicio.getPageAll($scope.pageInfo)
                .then(function (resp) {
                    $scope.pageList = resp.data;
                    $scope.objResult = resp.data.result;
                    const toastLiveExample = document.getElementById('liveToast')
                    const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
                    $scope.message = 'Se cargaron de forma correcta los resultados'
                    toastBootstrap.show()
                }, function (error) {
                   // $scope.setOptions(3, "Busqueda de Personas", error.data.ExceptionMessage);
                });
        };

        $scope.addPerson = function () {
            const toastLiveExample = document.getElementById('liveToast')
            const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)

            if ($scope.objPersonAdd.nombre != ''
                && $scope.objPersonAdd.aPaterno != ''
                && $scope.objPersonAdd.aMaterno != '') {
                directorioServicio.create($scope.objPersonAdd)
                    .then(function (resp) {
                        console.log(resp)
                        if (resp.data > 0) {

                            $scope.message = 'Se agrego de forma correcta la persona'
                            toastBootstrap.show()
                            $scope.objPersonAdd = {}
                            $scope.GetPaged()
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

        $scope.deletePerson = function (id) {
            const toastLiveExample = document.getElementById('liveToast')
            const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
            directorioServicio.delete(id)
                .$promise
                .then(function (resp)
                {
                    console.log(resp)
                    $scope.message = 'Se elimino de forma correcta la persona'
                    toastBootstrap.show()
                    $scope.GetPaged()
                },function (error) {
                    $scope.message = 'Se elimino de forma correcta la persona'
                    toastBootstrap.show()
                    $scope.GetPaged()
                    });
        }

        $scope.changePageSize = function () {
            $scope.serverSide.pageIndex = 1;
            $scope.GetAllPersonas();
        };

        $scope.redirectFactura = function (idPersona) {
            console.log(window.location)
            window.href("~/Factura/Index.cshtml");
        }
        $scope.clear = function () {
            $scope.pageInfo = {
                pageNumber: 1,
                pageSize: 10,
                search: '',
            };
            $scope.GetPaged()
        }

    });

}());