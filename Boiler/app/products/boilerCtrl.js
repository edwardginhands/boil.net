(function () {
    "use strict";
    angular
        .module("boilerManagement")
        .controller("BoilerCtrl",
                     ["$scope", 'statusService', "boilerResource", BoilerCtrl]);

    function BoilerCtrl($scope,statusService, boilerResource) {
        var vm = this;

        //vm.boiler = { isElementOn: true};
        boilerResource.query(function (data) { vm.boiler = data; });

        $scope.$on('statusService-received-data-event', function (event, args) {
            $scope.status1 = { element: "true" };

            if (args.element != vm.boiler.isElementOn || args.pump != vm.boiler.isPumpOn) {

                vm.boiler.isElementOn = args.element;
                vm.boiler.isPumpOn = args.pump;
                $scope.$apply();
            }

           // $scope.vm.boiler = $
        });
    }

    angular.module('boilerManagement').controller('buttonsController', function () {
        console.log('test');
        var _this = this;
        _this.singleModel = 1;
        _this.radioModel = 'Middle';
        _this.checkModel = {
            left: false,
            middle: true,
            right: false
        }});


}());
