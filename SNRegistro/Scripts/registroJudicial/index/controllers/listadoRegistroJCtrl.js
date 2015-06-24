(function () {
    'use strict';

    angular
        .module('GestorJudicialApp')
        .controller('listadoRegistroJCtrl', listadoRegistroJCtrl);

    listadoRegistroJCtrl.$inject = ['$rootScope', 'GestorJudicialResourse'];

    function listadoRegistroJCtrl($rootScope, GestorJudicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistroJudicial();
        vm.actualizar = function (RegistrosJudiciales) {
            $rootScope.$broadcast('actualizarRegistrosJudiciales', RegistroJudicial);
        }
        //Escuchando eventos de otros controladores
        $rootScope.$on("actualizarRegistrosJudiciales", function (event, objetoRecibido) {
            vm.RegistrosJudiciales = GestorJudicialResourse.RegistrosJudiciales.query();
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
        function traerRegistroJudicial() {
            vm.RegistrosJudiciales = GestorJudicialResourse.RegistrosJudiciales.query();
        }
        ////
        vm.listadoFn();

    }

})();