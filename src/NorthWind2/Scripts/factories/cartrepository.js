registrationModule.factory('cartRepository', function ($http, $q,$filter) {
    function cartItem(id, name, price, quantity) {

        this.name = name;
        this.price = price * 1;
        this.quantity = quantity * 1;
        this.id = id;
    }


    return {
        items: [],
        cartRepository: function() {
            // this.items = [];
            this.items = this.getCart();
        },
        getCart: function() {
            // var items = [];
            if ($.cookie('cart') != undefined) {
                this.items = JSON.parse($.cookie('cart'));

            }

            return this.items;
        },

        addCart: function(id, name, price, quantity) {


            if (quantity !== 0) {
                var items = this.getCart();
                var found = $filter('getById')(items, id);

                if (found === null) {
                    var item = new cartItem(id, name, price, quantity);
                    items.push(item);
                } else {
                    found.quantity = found.quantity + quantity;

                }

                $.cookie('cart', JSON.stringify(items), { path: '/' });

            }
        },

        removeItem: function(id, name, price, quantity) {
            var found = $filter('getById')(this.items, id);
            if (found != undefined) {
                this.items.splice(this.items.indexOf(found), 1);
                $.cookie('cart', JSON.stringify(this.items), { path: '/' });
            }
        },

        getTotalPrice: function() {
            var total = 0;
            for (var i = 0; i < this.items.length; i++) {
                var item = this.items[i];
                // if (id == null || item.id == id)
                //{
                total += item.quantity * item.price;
                // }
            }
            return total;
        },

        getTotalCount: function(id) {
            var count = 0;
            for (var i = 0; i < this.items.length; i++) {
                var item = this.items[i];
                if (id == null || item.id == id) {
                    count += (item.quantity);
                }
            }
            return count;
        },

        save: function() {
            var items = this.getCart();
            var deferred = $q.defer();
            if (items.length > 0) {

                $http.post('./Cart/Save', items).success(deferred.resolve).error(deferred.reject);
                //return deferred.promise;
            } else {
                deferred.reject("cart is empty, nothting to save");
                
            }
            return deferred.promise;
        }


}

});