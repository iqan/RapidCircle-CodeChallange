var mainController = function ($scope, authService, postsService) {
    
    $scope.newPost = {
        UserId:"",
        Text: ""
    };
    $scope.accessToken = "";
    $scope.posts = [];

    authService.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.post = function () {
        checkToken();
        postsService.doPost($scope.accessToken, $scope.newPost)
            .then(function (result) {
                console.log(result.data);
                $scope.newPost.Text = "";
            });
    }

    $scope.getPosts = function () {
        checkToken();
        $scope.posts = postsService.getPosts($scope.accessToken)
            .then(function (result) {
                $scope.posts = result.data;
            });
        console.log($scope.posts);
    };

    checkToken = function () {
        if ($scope.accessToken == null || $scope.accessToken== undefined) {
            authService.getAccessToken();
            $scope.accessToken = sessionStorage.getItem('iqans.accessToken');
        }
    };
}

mainController.$inject = ['$scope', 'authService', 'postsService'];