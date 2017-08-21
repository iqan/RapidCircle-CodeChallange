var mainFactory = function ($http) {

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

    fac.getPosts = function (token) {
        return $http({
            method: 'GET',
            url: 'https://localhost:44388/api/posts',
            headers: {
                'Authorization': 'bearer ' + token
            }
        });
    };

    fac.getPostById = function (token, postId) {
        $http({
            method: 'GET',
            url: 'https://localhost:44388/api/posts/' + postId,
            headers: {
                'Authorization': 'bearer ' + token
            }
        });
    };

    fac.doPost = function (token, post) {
        return $http({
            method: 'POST',
            url: 'https://localhost:44388/api/posts',
            headers: {
                'Authorization': 'bearer ' + token,
                'Content-Type' : 'application/json'
            },
            data: post
        });
    };

    return fac;
}

mainFactory.$inject = ['$http'];