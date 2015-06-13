(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('modalCrearCiudadanoCtrl', modalCrearCiudadanoCtrl);

    modalCrearCiudadanoCtrl.$inject = ['$scope', '$modalInstance', 'GestorMedicoResource'];

    function modalCrearCiudadanoCtrl($scope, $modalInstance, GestorMedicoResource) {
        /* jshint validthis:true */
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.nuevoParaCargar = function () {
            $scope.doctore = {};
        };

        $scope.guardar = function () {
            GestorMedicoResource.doctores.save($scope.doctore)
           .$promise.then(
               function (mensaje) {
                   if (!mensaje.error) {
                       $scope.doctore = mensaje.objetoDto;
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
