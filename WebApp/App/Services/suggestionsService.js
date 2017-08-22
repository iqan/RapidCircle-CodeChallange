var suggestionsService = function ($http) {

    var fac = {};

    fac.getSuggestions = function (token) {
        return $http({
            method: 'GET',
            url: 'https://localhost:44388/api/suggestion',
            headers: {
                'Authorization': 'bearer ' + token
            }
        });
    };

    return fac;
};

suggestionsService.$inject = ['$http'];