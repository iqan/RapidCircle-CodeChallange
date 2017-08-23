var edgesService = function ($http) {

    var fac = {};

    fac.getEdges = function (token) {
        return $http({
            method: 'GET',
            url: 'https://localhost:44388/api/edges',
            headers: {
                'Authorization': 'bearer ' + token
            }
        });
    };

    return fac;
};

edgesService.$inject = ['$http'];