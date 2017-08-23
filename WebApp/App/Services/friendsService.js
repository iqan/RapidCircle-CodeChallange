var friendsService = function ($http) {

    var fac = {};

    fac.addFriend = function (token, friend) {
        return $http({
            method: 'POST',
            url: 'https://localhost:44388/api/friends',
            headers: {
                'Authorization': 'bearer ' + token,
                'Content-Type': 'application/json'
            },
            data: friend
        });
    };

    fac.getFriends = function (token) {
        return $http({
            method: 'GET',
            url: 'https://localhost:44388/api/friends',
            headers: {
                'Authorization': 'bearer ' + token
            }
        });
    };

    return fac;
};

friendsService.$inject = ['$http'];