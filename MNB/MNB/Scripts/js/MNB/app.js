var app = angular.module('app', ['ngRoute']).
constant('MVC_URL', 'http://localhost:59648/stock');


app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/listall', {
        templateUrl: '/Content/viewTemplates/list.html',
        controller: 'ListAllController'
    }).
    when('/create', {
        templateUrl: '/Content/viewTemplates/create.html',
        controller: 'CreateController'
    }).
    otherwise({
        redirectTo: '/listall'
    });
}]);