var authService = function ($http) {

    var fac = {};

    fac.getAccessToken = function () {
        return $http({
                    method: 'GET',
                    url: '/home/GetAccessToken'
                });
    };

    return fac;
};

authService.$inject = ['$http'];