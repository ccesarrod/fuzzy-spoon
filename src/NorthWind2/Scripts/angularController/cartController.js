registrationModule.controller("cartController", function ($scope, $rootScope, cartRepository, notifications, userService) {
    //  $scope.items = [];
    $scope.items = cartRepository.getCart();

    $scope.cart = cartRepository;
    $scope.isUserLogin = userService.isLogin();
    $rootScope.lastVal = $scope.items.length;
    $rootScope.items = $scope.items;
    //   if ($cookies.cart) {
    //    $scope.items = $cookies.cart;

    //    }

    $scope.addCart = function (id, name, price, quantity) {
        // quantity = this.toNumber(quantity);
        if (quantity !== -100)
            cartRepository.addCart(id, name, price, quantity);
        else
            cartRepository.removeItem(id, name, price, quantity);
        // if (quantity > 0) {
        //         var item = new cartItem(id, name, price, quantity);
        //         $scope.items.push(item);
        //         $cookies.cart = $scope.items;
        $scope.items = cartRepository.getCart();
        $rootScope.lastVal = $scope.items.length;
        //   $rootScope.lastVal = $scope.items.length;
    }


    $scope.saveCart = function () {

        // notifications.showSuccess('Congrats! Life is great!');
        cartRepository.save().then(function () {
            notifications.showSuccess({
                message: 'Cart was updated',
                hideDelay: 1500, //ms
                hide: true //bool
            });
        },
        function (e) {
            console.log("error " + e + "");
            notifications.showError({
                message: 'Saving order failed: ' + e,
                hideDelay: 3000,
                hide: true
            });
        });
    }

    //$scope.getTotalPrice = function () {
    //    var total = 0;
    //    for (var i = 0; i < $scope.items.length; i++)
    //    {
    //        var item = $scope.items[i];
    //        if (id == null || item.id == id)
    //        {
    //            total += item.quantity * item.price;
    //        }
    //    }
    //    return total;
    //}




    //$scope.getTotalCount = function (id) {
    //    var count = 0;
    //    for (var i = 0; i < this.items.length; i++) {
    //        var item = this.items[i];
    //        if (id == null || item.id == id) {
    //            count += (item.quantity);
    //        }
    //    }
    //    return count;
    //}

    //$scope.getTotalPrice = function (id) {
    //     var total = 0;
    //     for (var i = 0; i < this.items.length; i++) {
    //         var item = this.items[i];
    //         if (id == null || item.sku == id) {
    //             total += (item.quantity * item.price);
    //         }
    //     }
    //     return total;
    // }

    /*  function cartItem(id, name, price, quantity) {
         
          this.Name = name;
          this.Price = price * 1;
          this.Quantity = quantity * 1;
          this.id = id;
      }*/
});