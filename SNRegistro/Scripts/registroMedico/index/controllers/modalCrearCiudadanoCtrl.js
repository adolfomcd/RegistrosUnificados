(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('ModalCrearCiudadanoCtrl', ModalCrearCiudadanoCtrl);

    ModalCrearCiudadanoCtrl.$inject = ['$scope', '$modalInstance', 'GestorMedicoResource'];

    function ModalCrearCiudadanoCtrl($scope, $modalInstance, GestorMedicoResource) {
        /* jshint validthis:true */
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.nuevoParaCargar = function () {
            $scope.Ciudadanos = {};
        };

        $scope.guardar = function () {
            GestorMedicoResource.Ciudadanos.save($scope.Ciudadano)
           .$promise.then(
               function (mensaje) {
                   if (!mensaje.error) {
                       $scope.Ciudadanos = mensaje.ObjetoDto;
                       $scope.mensajeDelServidor = mensaje.mensajeDelProceso;
                       //$rootScope.$broadcast('actualizarListadoProveedores', {});
                   } else {
                       $scope.mensajeDelServidor = mensaje.mensajeDelProceso;
                   }
               },
             function (mensaje) {
                 $scope.mensajeDelServidor = mensaje.data.mensajeDelProceso;
             }
           );
        }

    }
})();
