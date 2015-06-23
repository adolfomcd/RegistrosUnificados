(function () {
    'use strict';

    angular
        .module('GestorPolicialApp')
        .controller('busquedaCtrl', busquedaCtrl);

    busquedaCtrl.$inject = ['$rootScope', 'GestorPolicialResourse'];

    function busquedaCtrl($rootScope, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.GestorMedico = {};
        vm.Ciudadanos = GestorPolicialResourse.Ciudadanos.query();

        vm.buscar = function () {
            GestorPolicialResourse.FiltroPorRegistrosPolicialeDto.save(vm.GestorMedico)
                .$promise.then(function (respuesta) {
                    //Exitoso
                    $rootScope.$broadcast('actualizarListadoMedicoSegunFiltro', respuesta.ObjetoDto);
                },
            function () {
                //Error

            });
        }
    }
})();
