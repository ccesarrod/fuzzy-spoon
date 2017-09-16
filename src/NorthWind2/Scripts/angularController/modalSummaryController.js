registrationModule.controller("ModalSummaryCtrl", function ($scope, $modal) {

    $scope.open = function(size) {

        var modalInstance = $modal.open({
            templateUrl: './Templates/cartModalSummary.html',
            controller: 'ModalInstanceCtrl',
            size: size

        });
    }
});

registrationModule.controller('ModalInstanceCtrl', function ($scope, $modalInstance) {

    $scope.products = $scope.$parent.items;

    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});