var authService = function ($http) {

    var fac = {};

    fac.getAccessToken = function () {
        var req = {
            method: 'GET',
            url: '/home/GetAccessToken'
        };
        $http(req).then(function (token) {
            var atoken = token.data;
            console.log('got accesstoken. Token: ' + atoken);
            sessionStorage.setItem('iqans.accessToken', atoken);
        }, function (err) {
            console.log('error occurred while getting accesstoken. error: ' + err);
        });
    };

    return fac;
};

authService.$inject = ['$http'];