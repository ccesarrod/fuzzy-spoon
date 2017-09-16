var registrationModule = angular.module('registrationModule', ['ngRoute', 'ngNotificationsBar', 'ui.bootstrap'])
    .config(function ($routeProvider) {
       
        $routeProvider.when('/Payment', { templateUrl: './templates/payment.html', controller: 'cartController' });
        $routeProvider.when('/Customer', { templateUrl: './templates/customerDetails.html', controller: 'cartController' });
        $routeProvider.when('/Summary', { templateUrl: './templates/summary.html', controller: 'cartController' });
        $routeProvider.when('/Thankyou', { templateUrl: 'cart/thankyou', controller: 'cartController' });

   // $locationProvider.html5mode(true);
}).filter('getById', function() {
        return function(input, id) {
            var i = 0, len = input.length;
            for (; i < len; i++) {
                if (input[i].id == id) {
                    return input[i];
                }
            }
            return null;
        }
    });