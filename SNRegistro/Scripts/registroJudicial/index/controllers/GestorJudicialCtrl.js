(function () {
    'use strict';

    angular
        .module('GestorJudicialApp')
        .controller('GestorJudicialCtrl', GestorJudicialCtrl);

    GestorJudicialCtrl.$inject = ['$scope', '$rootScope', '$modal', 'GestorJudicialResourse'];

    function GestorJudicialCtrl($scope, $rootScope, $modal, GestorJudicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.Ciudadanos = GestorJudicialResourse.Ciudadanos.query();
        vm.FuncionarioJudicial = GestorJudicialResourse.FuncionarioJudicial.query();
        vm.Juzgados = GestorJudicialResourse.Juzgados.query();
        vm.ProcesosJudiciales = GestorJudicialResourse.ProcesosJudiciales.query();
       
        $scope.$watch('vm.GestorJudicial.ProcesoJudicial', function (newValue, oldValue) {
            if (newValue !== oldValue) {
                if (vm.GestorJudicial.ProcesoJudicial == null) { return; }
                GestorJudicialResourse.AccionesSegunProcesoID.query(
                    { ProcesoID: vm.GestorJudicial.ProcesoJudicial.ProcesoJudID },
                    function (respuesta) {
                        vm.Acciones = respuesta;
                        refrescarCampoSelect("GestorJudicial", vm.Acciones, "Accione", "AccionID");
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
            GestorJudicialResourse.RegistroMedicos.save(vm.GestorMedico)
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
        vm.crearCiudadano = function () {
            var modalInstance = $modal.open({
                templateUrl: 'ModalCrearCiudadano.html',
                controller: 'ModalCrearCiudadanoCtrl',
                size: 'lg'
            });
            modalInstance.result.then(function (selectedItem) {
            }, function () {
                vm.Ciudadanos = GestorMedicoResourse.Ciudadanos.query();
                //$log.info('Modal dismissed at: ' + new Date());
            });
        }
    }
})();
