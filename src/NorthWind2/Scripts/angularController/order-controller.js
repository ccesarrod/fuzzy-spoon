registrationModule.controller("orderController", function ($scope, orderRepository, cartRepository, notifications) {

    

    $scope.order = {}
    var x = orderRepository.getOrders();
    $scope.submitCart = function () {

        var order = $scope.order;
        order.items = cartRepository.getCart();
        orderRepository.save(order).then(function() {
                notifications.showSuccess({
                    message: 'Order Completed',
                    hideDelay: 1500, //ms
                    hide: true //bool
                });
               
                $.removeCookie('cart', { path: '/' });
            // $location.path('/Thankyou');
                window.location.href = 'cart/thankyou';
            },
            function(e) {

                console.log("error " + e + "");
                notifications.showError({
                    message: 'Order failed ' + e,
                    hideDelay: 2000,
                    hide: true
                });

            }); //var items = $rootScope.cart.getItems();
    };
});