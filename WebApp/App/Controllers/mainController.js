var mainController = function ($scope, mainFactory) {
    
    $scope.newPost = "";
    $scope.accessToken = "";
    $scope.posts = [];

    mainFactory.getAccessToken();
    $scope.accessToken = sessionStorage.getItem('iqans.accessToken');

    $scope.post = function () {        
        alert('new post: ' + $scope.newPost);
    }

    $scope.getPosts = function () {
        $scope.posts = mainFactory.getPosts($scope.accessToken);
    };
}

mainController.$inject = ['$scope', 'mainFactory'];