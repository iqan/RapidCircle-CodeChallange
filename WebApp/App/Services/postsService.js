var postsService = function ($http) {

    var fac = {};

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

postsService.$inject = ['$http'];