
(function () {
    'use strict';

    angular
        .module('GestorPolicialApp')
        .controller('listadoRegistroPCtrl', listadoRegistroPCtrl);

    listadoRegistroPCtrl.$inject = ['$rootScope', '$modal', 'GestorPolicialResourse'];

    function listadoRegistroPCtrl($rootScope, $modal, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistrosPoliciales();
        vm.actualizar = function (RegistrosPoliciale) {
            $rootScope.$broadcast('actualizarRegistrosPoliciale', RegistrosPoliciale);
        }
        vm.eliminar = function (RegistrosPoliciale) {
            var modalInstance = $modal.open({
                templateUrl: 'ModalEliminacion.html',
                controller: function ($scope, $modalInstance) {
                    $scope.RegistrosPoliciale = RegistrosPoliciale;
                    $scope.objeto = {};
                    $scope.objeto.id = RegistrosPoliciale.RegistroPolicialID;
                    $scope.objeto.mensaje = "Se eliminara la registro numero ";
                    $scope.ok = function () {
                        GestorPolicialResourse.RegistrosPoliciales
                            .delete({ id: RegistrosPoliciale.RegistroPolicialID },
                              function (respuesta) {
                                  $scope.respuesta = respuesta;
                                  traerRegistrosPoliciales();
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
        $rootScope.$on("actualizarListadoMedico", function (event, objetoRecibido) {
            vm.RegistrosPoliciales = GestorPolicialResourse.RegistrosPoliciales.query();
            vm.listadoFn();
        });
        $rootScope.$on("actualizarListadoMedicoSegunFiltro", function (event, objetoRecibido) {
            vm.RegistrosPoliciales = objetoRecibido;
        });

        ////Menu
        vm.menu = {};
        vm.listadoFn = function () {
            ocultar();
            vm.menu.listado.class = "active";
            vm.menu.listado.mostrar = true;
            traerRegistrosPoliciales();
            vm.pestanaSeleccionada = "listado";
        }
        vm.busquedaFn = function () {
            ocultar();
            vm.menu.busqueda.class = "active";
            vm.menu.busqueda.mostrar = true;
            vm.RegistrosPoliciales = {};
            vm.pestanaSeleccionada = "busqueda";
        }
        //////
        function ocultar() {
            vm.menu.listado = {};
            vm.menu.busqueda = {};
        }
        function traerRegistrosPoliciales() {
            vm.RegistrosPoliciales = GestorPolicialResourse.RegistrosPoliciales.query();
        }
        ////
        vm.listadoFn();

    }

})();