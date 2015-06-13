(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('listadoRegistroMCtrl', listadoRegistroMCtrl);

    listadoRegistroMCtrl.$inject = ['$rootScope', 'GestorMedicoResourse'];

    function listadoRegistroMCtrl($rootScope, GestorMedicoResource) {
        /* jshint validthis:true */
        var vm = this;
        vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
        vm.actualizar = function (RegistroMedicos) {
            $rootScope.$broadcast('actualizarRegistrosMedicos', RegistroMedicos);
        }
        //Escuchando eventos de otros controladores
        $rootScope.$on("actualizarListadoMedico", function (event, objetoRecibido) {
            vm.RegistroMedicos = GestorMedicoResource.RegistroMedicos.query();
        });

    }

})();
