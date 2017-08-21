var mainController = function ($scope, mainFactory) {
    
    $scope.newPost = {
        UserId:"",
        Text: ""
    };
    $scope.accessToken = "";
    $scope.posts = [];

    mainFactory.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.post = function () {
        checkToken();
        mainFactory.doPost($scope.accessToken, $scope.newPost)
            .then(function (result) {
                console.log(result.data);
                $scope.newPost.Text = "";
            });
    }

    $scope.getPosts = function () {
        checkToken();
        $scope.posts = mainFactory.getPosts($scope.accessToken)
            .then(function (result) {
                $scope.posts = result.data;
            });
        console.log($scope.posts);
    };

    checkToken = function () {
        if ($scope.accessToken == null || $scope.accessToken== undefined) {
            mainFactory.getAccessToken();
            $scope.accessToken = sessionStorage.getItem('iqans.accessToken');
        }
    };
}

mainController.$inject = ['$scope', 'mainFactory'];