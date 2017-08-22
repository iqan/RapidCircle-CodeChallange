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

    return fac;
};

friendsService.$inject = ['$http'];