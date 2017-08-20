var mainController = function ($scope) {

    $scope.newPost = "";

    $scope.post = function () {
        alert('new post: ' + $scope.newPost);
    }
}

mainController.$inject = ['$scope'];