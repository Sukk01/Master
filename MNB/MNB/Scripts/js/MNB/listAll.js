app.controller('ListAllController', function ($scope, AjaxService) {
    AjaxService.get('/GetAllParts').success(function (data) {
        $scope.parts = data;
    });

    $scope.underEdit = false;
    $scope.elementUnderEdit = null;

    $scope.add = function (element) {
        AjaxService.post("/Add/" + element.Id).success(function(){ 
            element.Added++;
            $scope.$broadcast('stockModified', null);
        });
    }

    $scope.withdraw = function (element) {
        AjaxService.post("/Withdraw/" + element.Id).success(function(){ 
            element.Withdrawn++;
            $scope.$broadcast('stockModified', null);
        });
    }

    $scope.startEdit = function (element) {
        $scope.elementUnderEdit = element;
        $scope.underEdit = true;
    }

    $scope.sendModify = function () {
        AjaxService.post("/Edit", $scope.elementUnderEdit).success(function(){ 
            $scope.underEdit = false;
            $scope.$broadcast('stockModified', null);
        });
        
    }

    $scope.delete = function (data) {
        AjaxService.deleteItem("/Delete/" + data.Id, null).success(function () {
            let i = $scope.parts.indexOf(data);
            if (i > -1) {
                $scope.parts.splice(i, 1);
            }

            $scope.$broadcast('stockModified', null);
        });
    }
});