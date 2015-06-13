(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('GestorMedicoCtrl', GestorMedicoCtrl);

    GestorMedicoCtrl.$inject = ['$scope', '$rootScope', '$modal', 'GestorMedicoResourse'];

    function GestorMedicoCtrl($scope, $rootScope, $modal, GestorMedicoResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.Ciudadanos = GestorMedicoResourse.Ciudadanos.query();
        vm.Doctores = GestorMedicoResourse.Doctores.query();
        vm.Hospitales = GestorMedicoResourse.Hospitales.query();
        vm.Procesos = GestorMedicoResourse.Procesos.query();
       
        $scope.$watch('vm.GestorMedico.Proceso', function (newValue, oldValue) {
            if (newValue !== oldValue) {
                if (vm.GestorMedico.Proceso == null) { return; }
                GestorMedicoResourse.AccionesSegunProcesoID.query(
                    { ProcesoID: vm.GestorMedico.Proceso.ProcesoID },
                    function (respuesta) {
                        vm.Acciones = respuesta;
                        refrescarCampoSelect("GestorMedico", vm.Acciones, "Accione", "AccionID");
                    });
            }
        });
        function refrescarCampoSelect(objetoPrincipal, array, nombreObjeto, campoID) {
            if (array != null) {
                for (var i = 0; i < array.length; i++) {
                    if (vm[objetoPrincipal][nombreObjeto] == null) { break; }
                    if (vm[objetoPrincipal][nombreObjeto][campoID] == null) { break; }
                    if (array[i][campoID] == vm[objetoPrincipal][nombreObjeto][campoID]) {
                        vm[objetoPrincipal][nombreObjeto] = array[i];
                        break;
                    }
                };
            }

        }
        //Eventos de usuario
        vm.guardar = function () {
            GestorMedicoResourse.RegistroMedicos.save(vm.GestorMedico)
            .$promise.then(function (respuesta) {
                //Exitoso
                vm.GestorMedico = respuesta.ObjetoDto;
                vm.MensajeDelProceso = respuesta.MensajeDelProceso;
                refrescarCampoSelect("GestorMedico", vm.Procesos, "Proceso", "ProcesoID");
                refrescarCampoSelect("GestorMedico", vm.Acciones, "Accione", "AccionID");
                $rootScope.$broadcast('actualizarListadoMedico', {});
            },
            function () {
                //Error

            });
        }
    }
})();
