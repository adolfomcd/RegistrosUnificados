(function () {
    'use strict';

    angular
        .module('GestorJudicialApp')
        .controller('listadoRegistroJCtrl', listadoRegistroJCtrl);

    listadoRegistroJCtrl.$inject = ['$rootScope', 'GestorJudicialResourse'];

    function listadoRegistroJCtrl($rootScope, GestorJudicialResource) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistroJudicial();
        vm.actualizar = function (RegistroJudicial) {
            $rootScope.$broadcast('actualizarRegistroJudicial', RegistroJudicial);
        }
        //Escuchando eventos de otros controladores
        $rootScope.$on("actualizarListadoJudicial", function (event, objetoRecibido) {
            vm.RegistroJudicial = GestorJudicialResource.RegistroJudicial.query();
        });

        ////Menu
        vm.menu = {};
        vm.listadoFn = function () {
            ocultar();
            vm.menu.listado.class = "active";
            vm.menu.listado.mostrar = true;
            traerRegistroJudicial();
            vm.pestanaSeleccionada = "listado";
        }
        vm.busquedaFn = function () {
            ocultar();
            vm.menu.busqueda.class = "active";
            vm.menu.busqueda.mostrar = true;
            vm.RegistroJudicial = {};
            vm.pestanaSeleccionada = "busqueda";
        }
        //////
        function ocultar() {
            vm.menu.listado = {};
            vm.menu.busqueda = {};
        }
        function traerRegistroJudicial() {
            vm.RegistroJudicial = GestorJudicialResource.RegistroJudicial.query();
        }
        ////
        vm.listadoFn();

    }

})();