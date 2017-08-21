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
        var req = {
            method: 'GET',
            url: 'https://localhost:44388/api/posts',
            headers: {
                'Authorization': 'bearer '+ token
            }
        };
        $http(req).then(function (result) {
            var posts = result.data;
            console.log('got posts. Posts: ' + posts);
        }, function (err) {
            console.log('error occurred while getting posts.');
            console.log(err);
        });
    };

    fac.doPost = function (post) {
        var req = {
            method: 'POST',
            url: 'https://localhost:44388/api/posts',
            headers: {
                'Content-Type': undefined
            },
            data: { post: post }
        };
        $http(req).then(function (result) {
            
        }, function (err) {
            console.log('error occurred while posting post. error: ' + err);
        });
    };

    return fac;
}

mainFactory.$inject = ['$http'];