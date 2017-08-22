var app = angular.module('app', []);

app.controller('mainController', mainController);

app.factory('authService', authService);
app.factory('postsService', postsService);
app.factory('suggestionsService', suggestionsService);