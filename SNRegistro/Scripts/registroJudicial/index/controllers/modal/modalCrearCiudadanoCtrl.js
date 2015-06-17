(function () {
    'use strict';

    angular
        .module('GestorMedicoApp')
        .controller('ModalCrearCiudadanoCtrl', ModalCrearCiudadanoCtrl);

    ModalCrearCiudadanoCtrl.$inject = ['$scope', '$modalInstance', 'GestorMedicoResourse'];

    function ModalCrearCiudadanoCtrl($scope, $modalInstance, GestorMedicoResourse) {
        /* jshint validthis:true */
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        $scope.nuevoParaCargar = function () {
            $scope.Ciudadano = {};
        };

        $scope.guardar = function () {
            GestorMedicoResourse.Ciudadanos.save($scope.Ciudadano)
           .$promise.then(
               function (mensaje) {
                   if (!mensaje.error) {
                       $scope.Ciudadano = mensaje.ObjetoDto;
                       $scope.MensajeDelProceso = mensaje.MensajeDelProceso;
                       //$rootScope.$broadcast('actualizarListadoProveedores', {});
                   } else {
                       $scope.MensajeDelProceso = mensaje.MensajeDelProceso;
                   }
               },
             function (mensaje) {
                 $scope.MensajeDelProceso = mensaje.data.MensajeDelProceso;
             }
           );
        }

    }
})();
