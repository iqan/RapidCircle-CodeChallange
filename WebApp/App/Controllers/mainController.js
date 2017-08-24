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

    $scope.post = function () {
        checkToken();
        $scope.newPost.DatePosted = new Date();
        postsService.doPost($scope.accessToken, $scope.newPost)
            .then(function (result) {
                console.log(result.data);
                $scope.newPost.Text = "";
                alert('Post successfull.');
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

    $scope.addFriend = function (suggestion, index) {
        var friend = { FriendId: suggestion.UserId };
        console.log('adding friendId: ' + friend.FriendId);
        friendsService.addFriend($scope.accessToken, friend)
            .then(function (result) {
                alert('friend added');
                $scope.suggestions.splice(index, 1);
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
                        console.log('token: ' + $scope.accessToken);
                        sessionStorage.setItem('iqans.accessToken', result.data);
                    });
            }else{
                $scope.accessToken = tokenFromStorage;
            }
        }
    };

    initPage = function () {
        authService.getAccessToken().then(function (result) {
            sessionStorage.removeItem('iqans.accessToken');
            $scope.accessToken = result.data;
            console.log('auth service response:');
            console.log(result.data);
            sessionStorage.setItem('iqans.accessToken', result.data);
            checkToken();
            $scope.getPosts();
            $scope.getSuggestions();
        });
    };

    initPage();
}

mainController.$inject = ['$scope', 'authService', 'postsService', 'suggestionsService', 'friendsService'];