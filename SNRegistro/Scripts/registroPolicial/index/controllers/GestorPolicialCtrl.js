(function () {
    'use strict';

    angular
        .module('GestorPolicialApp')
        .controller('GestorPolicialCtrl', GestorPolicialCtrl);

    GestorPolicialCtrl.$inject = ['$scope', '$rootScope', '$modal', 'GestorPolicialResourse'];

    function GestorPolicialCtrl($scope, $rootScope, $modal, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.Ciudadanos = GestorPolicialResourse.Ciudadanos.query();
        vm.Policias = GestorPolicialResourse.Policias.query();
        vm.Comisarias = GestorPolicialResourse.Comisarias.query();
        vm.ProcesosPoliciales = GestorPolicialResourse.ProcesosPoliciales.query();

        $scope.$watch('vm.GestorPolicial.ProcesosPoliciale', function (newValue, oldValue) {
            if (newValue !== oldValue) {
                if (vm.GestorPolicial.ProcesosPoliciale == null) { return; }
                GestorPolicialResourse.AccionesPolicialesSegunProcesoPolicialID.query(
                    { ProcesoPolicialID: vm.GestorPolicial.ProcesosPoliciale.ProcesoPolicialID },
                    function (respuesta) {
                        vm.AccionesPoliciales = respuesta;
                        refrescarCampoSelect("GestorPolicial", vm.AccionesPoliciales, "AccionesPoliciale", "AccPolID");
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
            vm.GestorPolicial = {};
        }
        vm.guardar = function () {
            GestorPolicialResourse.RegistrosPoliciales.save(vm.GestorPolicial)
            .$promise.then(function (respuesta) {
                //Exitoso
                vm.GestorPolicial = respuesta.ObjetoDto;
                vm.MensajeDelProceso = respuesta.MensajeDelProceso;
                refrescarCampoSelect("GestorPolicial", vm.ProcesosPoliciales, "ProcesosPoliciale", "ProcesoPolicialID");
                refrescarCampoSelect("GestorPolicial", vm.AccionesPoliciales, "AccionesPoliciale", "AccPolID");
                $rootScope.$broadcast('actualizarListadoPolicial', {});
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
                vm.Ciudadanos = GestorPolicialResourse.Ciudadanos.query();
                //$log.info('Modal dismissed at: ' + new Date());
            });
        }
        //Captura de broadcast
        $rootScope.$on("actualizarRegistrosPoliciale", function (event, objetoRecibido) {
            vm.GestorPolicial = objetoRecibido;
            vm.GestorPolicial.ProcesosPoliciale = vm.GestorPolicial.AccionesPoliciale.ProcesosPoliciale;
            refrescarCampoSelect("GestorPolicial", vm.ProcesosPoliciales, "ProcesosPoliciale", "ProcesoPolicialID");
            //refrescarCampoSelect("GestorPolicial", vm.AccionesPoliciales, "Accione", "AccPolID");
        });
    }
})();
