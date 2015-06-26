(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('listadoRegistroMCtrl', listadoRegistroMCtrl);

    listadoRegistroMCtrl.$inject = ['$rootScope', '$modal', 'GestorMedicoResourse'];

    function listadoRegistroMCtrl($rootScope, $modal, GestorMedicoResource) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistroMedicos();
        vm.actualizar = function (RegistroMedico) {
            $rootScope.$broadcast('actualizarRegistroMedico', RegistroMedico);
        }
        vm.eliminar = function (RegistroMedico) {
            var modalInstance = $modal.open({
                templateUrl: 'ModalEliminacion.html',
                controller: function ($scope, $modalInstance) {
                    $scope.RegistroMedico = RegistroMedico;
                    $scope.objeto = {};
                    $scope.objeto.id = RegistroMedico.RegistroMedicoID;
                    $scope.objeto.mensaje = "Se eliminara la registro numero ";
                    $scope.ok = function () {
                        GestorMedicoResource.RegistroMedicos
                            .delete({ id: RegistroMedico.RegistroMedicoID },
                              function (respuesta) {
                                  $scope.respuesta = respuesta;
                                  traerRegistroMedicos();
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
            vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
            vm.listadoFn();
        });
        $rootScope.$on("actualizarListadoMedicoSegunFiltro", function (event, objetoRecibido) {
            vm.RegistroMedicos = objetoRecibido;
        });

        ////Menu
        vm.menu = {};
        vm.listadoFn = function () {
            ocultar();
            vm.menu.listado.class = "active";
            vm.menu.listado.mostrar = true;
            traerRegistroMedicos();
            vm.pestanaSeleccionada = "listado";
        }
        vm.busquedaFn = function () {
            ocultar();
            vm.menu.busqueda.class = "active";
            vm.menu.busqueda.mostrar = true;
            vm.RegistroMedicos = {};
            vm.pestanaSeleccionada = "busqueda";
        }
        //////
        function ocultar() {
            vm.menu.listado = {};
            vm.menu.busqueda = {};
        }
        function traerRegistroMedicos() {
            vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
        }
        ////
        vm.listadoFn();

    }

})();