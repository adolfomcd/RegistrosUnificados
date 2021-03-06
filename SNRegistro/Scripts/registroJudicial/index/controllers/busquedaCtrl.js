﻿(function () {
    'use strict';

    angular
        .module('GestorJudicialApp')
        .controller('busquedaCtrl', busquedaCtrl);

    busquedaCtrl.$inject = ['$rootScope', 'GestorJudicialResourse'];

    function busquedaCtrl($rootScope, GestorJudicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.GestorJudicial = {};
        vm.Ciudadanos = GestorJudicialResourse.Ciudadanos.query();

        vm.buscar = function () {
            GestorJudicialResourse.FiltroPorRegistroJudicialDto.save(vm.GestorJudicial)
                .$promise.then(function (respuesta) {
                    //Exitoso
                    $rootScope.$broadcast('actualizarListadoJudicialSegunFiltro', respuesta.ObjetoDto);
                },
            function () {
                //Error

            });
        }
    }
})();
