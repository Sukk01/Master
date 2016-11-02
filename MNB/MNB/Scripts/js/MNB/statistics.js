app.controller('StatisticsController', function ($scope, AjaxService) {
    AjaxService.get('/Statistics').success(function (data) {
        $scope.statData = data;
    }).
    error(function (data) {
        alert('Error during process');
    });

    $scope.$on('stockModified', function (event, d) {
        AjaxService.get('/Statistics').success(function (data) {
            $scope.statData = data;
        }).
        error(function (data) {
            alert('Error during process');
        });
    });//eventList
});