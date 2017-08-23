var mainController = function ($scope, authService, postsService, suggestionsService, friendsService) {
    
    $scope.newPost = {
        UserId:"",
        Text: ""
    };
    $scope.accessToken = "";
    $scope.posts = [];
    $scope.totalPosts = 5;
    $scope.suggestions = [];
    $scope.totalSuggestions = 1;
    $scope.errorMessage;

    authService.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.post = function () {
        checkToken();
        $scope.newPost.DatePosted = new Date();
        postsService.doPost($scope.accessToken, $scope.newPost)
            .then(function (result) {
                console.log(result.data);
                $scope.newPost.Text = "";
                $scope.posts.push(result.data);
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
                console.log('got suggestions');
                console.log(result.data);
            });
    };

    $scope.loadSuggestions = function () {
        if ($scope.totalSuggestions <= $scope.suggestions.length) {
            $scope.totalSuggestions += 1;
        }
    };

    $scope.addFriend = function (suggestion) {
        var friend = { FriendId: suggestion.UserId };
        console.log('adding friendId: ' + friend.FriendId);
        friendsService.addFriend($scope.accessToken, friend)
            .then(function (result) {
                console.log('friend added');
                console.log(result.data);
            });
    };

    checkToken = function () {
        if ($scope.accessToken === null || $scope.accessToken === undefined) {
            tokenFromStorage = sessionStorage.getItem('iqans.accessToken');
            if ($scope.accessToken === null || $scope.accessToken === undefined) {
                authService.getAccessToken()
                    .then(function (result) {
                        $scope.accessToken = result.data;
                        sessionStorage.setItem('iqans.accessToken', result.data);
                    });
            }else{
                $scope.accessToken = tokenFromStorage;
            }
        }
    };

    $scope.getPosts();
    $scope.getSuggestions();
}

mainController.$inject = ['$scope', 'authService', 'postsService', 'suggestionsService', 'friendsService'];