(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('busquedaCtrl', busquedaCtrl);

    busquedaCtrl.$inject = ['GestorMedicoResourse'];

    function busquedaCtrl(GestorMedicoResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.GestorMedico = {};
        vm.Ciudadanos = GestorMedicoResourse.Ciudadanos.query();
    }
})();
