app.controller('CreateController', function ($scope, AjaxService, $location) {
    $scope.create = function () {
        AjaxService.post("/CreatePart", $scope.part).success(function () {
            $location.path("/listall");
        })
    }
})