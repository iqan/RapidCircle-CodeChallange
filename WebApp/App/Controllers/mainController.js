var mainController = function ($scope, authService, postsService, suggestionsService) {
    
    $scope.newPost = {
        UserId:"",
        Text: ""
    };
    $scope.accessToken = "";
    $scope.posts = [];
    $scope.totalPosts = 1;
    $scope.suggestions = [];

    authService.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.post = function () {
        checkToken();
        $scope.newPost.DatePosted = new Date();
        postsService.doPost($scope.accessToken, $scope.newPost)
            .then(function (result) {
                console.log(result.data);
                $scope.newPost.Text = "";
            });
    };

    $scope.getPosts = function () {
        checkToken();
        postsService.getPosts($scope.accessToken)
            .then(function (result) {
                $scope.posts = result.data;
            });
        //console.log($scope.posts);
    };

    $scope.loadPosts = function () {
        if ($scope.totalPosts <= $scope.posts.length) {
            $scope.totalPosts += 1;
        }
    };

    $scope.getSuggestions = function () {
        checkToken();
        suggestionsService.getSuggestions($scope.accessToken)
            .then(function (result) {
                $scope.suggestions = result.data;
            });
        console.log('got suggestions');
        console.log($scope.suggestions);
    };

    checkToken = function () {
        if ($scope.accessToken === null || $scope.accessToken === undefined) {
            authService.getAccessToken();
            $scope.accessToken = sessionStorage.getItem('iqans.accessToken');
        }
    };
}

mainController.$inject = ['$scope', 'authService', 'postsService', 'suggestionsService'];