(function () {
    'use strict';

    angular
        .module('GestorPololicialApp')
        .controller('GestorPololicialCtrl', GestorPololicialCtrl);

    GestorPololicialCtrl.$inject = ['$scope', '$rootScope', '$modal', 'GestorPolicialResourse'];

    function GestorPololicialCtrl($scope, $rootScope, $modal, GestorPolicialResourse) {
        /* jshint validthis:true */
        var vm = this;
        vm.Ciudadanos = GestorPolicialResourse.Ciudadanos.query();
        vm.Policias = GestorPolicialResourse.Policias.query();
        vm.Comisarias = GestorPolicialResourse.Comisarias.query();
        vm.ProcesosPoliciales = GestorPolicialResourse.ProcesosPoliciales.query();
       
        $scope.$watch('vm.GestorPolicial.ProcesosPoliciales', function (newValue, oldValue) {
            if (newValue !== oldValue) {
                if (vm.GestorPolicial.ProcesosPoliciales == null) { return; }
                GestorPolicialResourse.AccionesPolicialesSegunProcesoPolicialID.query(
                    { ProcesoPolicialID: vm.GestorPolicial.ProcesosPoliciales.ProcesoPolicialID },
                    function (respuesta) {
                        vm.AccionesPoliciales = respuesta;
                        refrescarCampoSelect("GestorPolicial", vm.AccionesPoliciales, "AccionesPoliciales", "AccPolID");
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
            GestorPolicialResourse.GestorPolicial.save(vm.GestorPolicial)
            .$promise.then(function (respuesta) {
                //Exitoso
                vm.GestorPolicial = respuesta.ObjetoDto;
                vm.MensajeDelProceso = respuesta.MensajeDelProceso;
                refrescarCampoSelect("GestorPolicial", vm.ProcesosPoliciales, "ProcesosPoliciales", "ProcesoPolicialID");
                refrescarCampoSelect("GestorPolicial", vm.Acciones, "AccionesPoliciales", "AccPolID");
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
    }
})();
