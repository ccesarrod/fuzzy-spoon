registrationModule.factory('orderRepository', function ($http, $q) {

    return {
        
        save: function (order)
        {
            var deferred = $q.defer();
            if (order.items.length > 0)
            {
               
                $http.post('./Orders/Save', order).success(deferred.resolve).error(deferred.reject);
               // return deferred.promise;
            }
            else {
                deferred.reject("cart is empty, nothting to save");

            }

            return deferred.promise;
        },

        getOrders:function() {
            var deferred = $q.defer();
            $http.get('http://localhost/orderservice/api/orders').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }

    };
});