(function () {
    'use strict';

    angular
        .module('GestorJudicialApp')
        .controller('listadoRegistroJCtrl', listadoRegistroJCtrl);

    listadoRegistroJCtrl.$inject = ['$rootScope', '$modal','GestorJudicialResourse'];

    function listadoRegistroJCtrl($rootScope, $modal, GestorJudicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistrosJudiciales();
        vm.actualizar = function (RegistrosJudiciale) {
            $rootScope.$broadcast('actualizarRegistrosJudiciale', RegistrosJudiciale);
        }
        vm.eliminar = function (RegistrosJudiciale) {
            var modalInstance = $modal.open({
                templateUrl: 'ModalEliminacion.html',
                controller: function ($scope, $modalInstance) {
                    $scope.RegistrosJudiciale = RegistrosJudiciale;
                    $scope.objeto = {};
                    $scope.objeto.id = RegistrosJudiciale.RegistroJudicialID;
                    $scope.objeto.mensaje = "Se eliminara la registro numero ";
                    $scope.ok = function () {
                        GestorMedicoResource.RegistrosJudiciales
                            .delete({ id: RegistrosJudiciale.RegistroJudicialID },
                              function (respuesta) {
                                  $scope.respuesta = respuesta;
                                  traerRegistrosJudiciales();
                              });

                        //$rootScope.$broadcast('actualizarTodos', {});
                    };
                    $scope.cancel = function () {
                        $modalInstance.dismiss('cancel');
                    };
                },
                size: 'sm'
            });
        }
        //Escuchando eventos de otros controladores
        $rootScope.$on("actualizarListadoJudicial", function (event, objetoRecibido) {
            vm.RegistrosJudiciales = GestorJudicialResourse.RegistrosJudiciales.query();
            vm.listadoFn();
        });
        $rootScope.$on("actualizarListadoJudicialSegunFiltro", function (event, objetoRecibido) {
            vm.RegistrosJudiciales = objetoRecibido;
        });

        ////Menu
        vm.menu = {};
        vm.listadoFn = function () {
            ocultar();
            vm.menu.listado.class = "active";
            vm.menu.listado.mostrar = true;
            traerRegistrosJudiciales();
            vm.pestanaSeleccionada = "listado";
        }
        vm.busquedaFn = function () {
            ocultar();
            vm.menu.busqueda.class = "active";
            vm.menu.busqueda.mostrar = true;
            vm.RegistrosJudiciales = {};
            vm.pestanaSeleccionada = "busqueda";
        }
        //////
        function ocultar() {
            vm.menu.listado = {};
            vm.menu.busqueda = {};
        }
        function traerRegistrosJudiciales() {
            vm.RegistrosJudiciales = GestorJudicialResourse.RegistrosJudiciales.query();
        }
        ////
        vm.listadoFn();

    }

})();