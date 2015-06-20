(function () {
    'use strict';

    angular
        .module('GestorPolicialApp')
        .controller('listadoRegistroPCtrl', listadoRegistroPCtrl);

    listadoRegistroPCtrl.$inject = ['$rootScope', 'GestorPolicialResourse'];

    function listadoRegistroPCtrl($rootScope, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistroMedicos();
        vm.actualizar = function (RegistroPoliciales) {
            $rootScope.$broadcast('actualizarRegistroPolicial', RegistroMedicos);
        }
        //Escuchando eventos de otros controladores
        $rootScope.$on("actualizarListadoPolicial", function (event, objetoRecibido) {
            vm.RegistrosPoliciales = GestorPolicialResourse.RegistrosPoliciales.query();
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