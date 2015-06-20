//(function () {
//    'use strict';

//    angular
//        .module('GestorMedicoApp')
//        .controller('listadoRegistroMCtrl', listadoRegistroMCtrl);

//    listadoRegistroMCtrl.$inject = ['$rootScope', 'GestorMedicoResourse'];

//    function listadoRegistroMCtrl($rootScope, GestorMedicoResource) {
//        /* jshint validthis:true */
//        var vm = this;
//        vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
//        vm.actualizar = function (RegistroMedicos) {
//            $rootScope.$broadcast('actualizarRegistrosMedicos', RegistroMedicos);
//        }
//        //Escuchando eventos de otros controladores
//        $rootScope.$on("actualizarListadoMedico", function (event, objetoRecibido) {
//            vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
//        });

//    }

//})();
(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('listadoRegistroMCtrl', listadoRegistroMCtrl);

    listadoRegistroMCtrl.$inject = ['$rootScope', 'GestorMedicoResourse'];

    function listadoRegistroMCtrl($rootScope, GestorMedicoResource) {
        /* jshint validthis:true */
        var vm = this;
        traerRegistroMedicos();
        vm.actualizar = function (RegistroMedicos) {
            $rootScope.$broadcast('actualizarRegistrosMedicos', RegistroMedicos);
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