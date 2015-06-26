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
        vm.FuncionariosJudiciales = GestorJudicialResourse.FuncionariosJudiciales.query();
        vm.Juzgados = GestorJudicialResourse.Juzgados.query();
        vm.ProcesosJudiciales = GestorJudicialResourse.ProcesosJudiciales.query();

        $scope.$watch('vm.GestorJudicial.ProcesosJudiciale', function (newValue, oldValue) {
            if (newValue !== oldValue) {
                if (vm.GestorJudicial.ProcesosJudiciale == null) { return; }
                GestorJudicialResourse.AccionesJudicialesSegunProcesoJudID.query(
                    { ProcesoJudID: vm.GestorJudicial.ProcesosJudiciale.ProcesoJudID },
                    function (respuesta) {
                        vm.AccionesJudiciales = respuesta;
                        refrescarCampoSelect("GestorJudicial", vm.AccionesJudiciales, "AccionesJudiciale", "AccJudID");
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
        vm.nuevoParaCargar = function () {
            vm.GestorJudicial = {};
        }
        vm.guardar = function () {
            GestorJudicialResourse.RegistrosJudiciales.save(vm.GestorJudicial)
            .$promise.then(function (respuesta) {
                //Exitoso
                vm.GestorJudicial = respuesta.ObjetoDto;
                vm.MensajeDelProceso = respuesta.MensajeDelProceso;
                refrescarCampoSelect("GestorJudicial", vm.ProcesosJudiciales, "ProcesosJudiciale", "ProcesoJudID");
                refrescarCampoSelect("GestorJudicial", vm.AccionesJudiciales, "AccionesJudiciale", "AccJudID");
                $rootScope.$broadcast('actualizarListadoJudicial', {});
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
                vm.Ciudadanos = GestorJudicialResourse.Ciudadanos.query();
                //$log.info('Modal dismissed at: ' + new Date());
            });
        }
        //Captura de broadcast
        $rootScope.$on("actualizarRegistrosJudiciale", function (event, objetoRecibido) {
            vm.GestorJudicial = objetoRecibido;
            vm.GestorJudicial.ProcesosJudiciale = vm.GestorJudicial.AccionesJudiciale.ProcesosJudiciale;
            refrescarCampoSelect("GestorJudicial", vm.ProcesosJudiciales, "ProcesosJudiciale", "ProcesoJudID");
            //refrescarCampoSelect("GestorJudicial", vm.AccionesJudiciales, "AccionesJudiciale", "AccJudID");
        });
    }
})();
