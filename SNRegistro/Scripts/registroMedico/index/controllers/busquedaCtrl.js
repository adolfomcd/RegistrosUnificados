(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('busquedaCtrl', busquedaCtrl);

    busquedaCtrl.$inject = ['$rootScope','GestorMedicoResourse'];

    function busquedaCtrl($rootScope, GestorMedicoResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.GestorMedico = {};
        vm.Ciudadanos = GestorMedicoResourse.Ciudadanos.query();

        vm.buscar = function () {
            GestorMedicoResourse.FiltroPorRegistroMedicoDto.save(vm.GestorMedico)
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
