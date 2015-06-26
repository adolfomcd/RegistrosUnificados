(function () {
    'use strict';

    angular
        .module('GestorPolicialApp')
        .controller('busquedaCtrl', busquedaCtrl);

    busquedaCtrl.$inject = ['$rootScope', 'GestorPolicialResourse'];

    function busquedaCtrl($rootScope, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.GestorPolicial = {};
        vm.Ciudadanos = GestorPolicialResourse.Ciudadanos.query();

        vm.buscar = function () {
            GestorPolicialResourse.FiltroPorRegistrosPolicialeDto.save(vm.GestorPolicial)
                .$promise.then(function (respuesta) {
                    //Exitoso
                    $rootScope.$broadcast('actualizarListadoPolicialSegunFiltro', respuesta.ObjetoDto);
                },
            function () {
                //Error

            });
        }
    }
})();
