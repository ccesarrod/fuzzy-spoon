registrationModule.factory('userService', function ($http, $q) {

    return {

        isLogin: function () {
            var auth = $.cookie('.AspNet.ApplicationCookie');
            return auth != undefined;
        }

    };
});