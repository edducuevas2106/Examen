"use strict";
(function () {
    var app = angular.module("mainApp");
    app.controller("directorioController", function ($scope, directorioServicio) {
        $scope.pageSides = [5, 10, 25, 50];
        $scope.pageList = {
            FirstItemOnPage: 0,
            HasNextPage: false,
            HasPreviousPage: false,
            IsFirstPage: true,
            IsLastPage: true,
            LastItemOnPage: 0,
            PageCount: 0,
            PageNumber: 0,
            PageSize: 0,
            TotalItemCount: 0
        };

        $scope.pageInfo = {
            pageNumber: 1,
            pageSize: 10,
            search: '',
        };
        $scope.lstPersonas = {}

        $scope.initApp = function () {
            //var dtMax = new Date(new Date().getTime() - new Date().getTimezoneOffset() * 60000).toISOString().split("T")[0];
            //document.getElementById('dtTxt').max = dtMax;
            $scope.GetPaged();
        }

        //$scope.GetAllPersonas = function () {
        //    directorioServicio.getAll()
        //        .$promise
        //        .then(function (resp) {
        //            $scope.lstPersonas = resp;
        //        },
        //        function (error) {
        //            console.log(error)
        //            //NProgress.done();
        //        });
        //};

        $scope.GetPaged = function () {
            directorioServicio.getPageAll($scope.serverSide)
                .then(function (resp) {
                    console.log(resp)
                    //$scope.pageList = resp.data;
                    //$scope.objResult = resp.data.Result;

                }, function (error) {
                    $scope.setOptions(3, "Busqueda de Personas", error.data.ExceptionMessage);
                });
        };

        $scope.setOptions = function (i, title, msg) {
            if (i == 1) {///Info
                toaster.pop('info', title, msg);
            }
            if (i == 2) {//Warning
                toaster.pop('warning', title, msg);
            }
            if (i == 3) {///Error
                toaster.pop('error', title, msg);
            }
            if (i == 4) {///success
                toaster.pop('success', title, msg);
            }
        };

        $scope.changePageSize = function () {
            $scope.serverSide.pageIndex = 1;
            $scope.GetAllPersonas();
        };


        $scope.initApp = function () {
            //var dtMax = new Date(new Date().getTime() - new Date().getTimezoneOffset() * 60000).toISOString().split("T")[0];
            //document.getElementById('dtTxt').max = dtMax;
            $scope.GetPaged();
        }

        //$scope.clear = function () {
        //    $scope.objAddResult = {};
        //    $scope.setOptions(1, "Modulo Personas", "Se limpiaron los filtros correctamente");
        //}

    });

}());