(function () {
    "use strict";
    angular
        .module("boilerManagement")
        .controller("BoilerCtrl",
                     ["$scope","$interval","$timeout",'$rootScope','$resource','appSettings', "boilerResource", BoilerCtrl]);


    function BoilerCtrl($scope, $interval, $timeout, $rootScope, $resource,appSettings, boilerResource) {
        var vm = this;
        vm.boilerStatus = { isElementOn: false, isPumpOn: false };
        //vm.boiler = { isElementOn: true};
        boilerResource.query(function (data) { vm.boiler = data; });

        $scope.isBurstOn = false;
        vm.burstTime = 1;
        vm.burstInterval = 10;

        $scope.gaugeInit = false;
        $scope.chartOptions = {
            width: 100, height: 100,
            redFrom: 90, redTo: 100,
            yellowFrom: 75, yellowTo: 90,
            minorTicks: 5
        };



        $interval(function () {
            var res = $resource(appSettings.serverPath + "/api/boiler", {}, { query: { method: "GET", isArray: false }, update: { method: 'PUT' } });
            var y = res.query({}, function (data) {

                if (data.isElementOn != vm.boilerStatus.isElementOn || data.isPumpOn != vm.boilerStatus.isPumpOn) {

                    vm.boilerStatus.isElementOn = data.isElementOn;
                    vm.boilerStatus.isPumpOn = data.isPumpOn;
                    //$scope.$apply();
                }

                if (!$scope.gaugeInit) {
                    $scope.chartData = google.visualization.arrayToDataTable([
                        ['Label', 'Value'],
                        ['Temp', 0]
                    ]);

                    var div = document.getElementById('chartDiv');
                    $scope.chart = new google.visualization.Gauge(div);
                    $scope.gaugeInit = true;
                }
                $scope.chartData.setValue(0, 1, Math.round(data.actualTemp));
                $scope.chart.draw($scope.chartData, $scope.chartOptions);


            });
        }, 500);



        $scope.change = function () {
            var a = 1;

            vm.boiler.$save(
                        function (data) {
                            vm.originalProduct = angular.copy(data);
                            vm.message = ".. . Save Complete";
                        },
                        function (response) {
                            vm.message = response.statusText + "\r\n";
                            if (response.data.exceptionMessage) { vm.message += response.data.exceptionMessage; }
                        })
        }

        $scope.click = function (e) {
            var a = 1;
            var id = e.target.id;
            var x = e.target.getAttribute("statusValue");
            var val = e.target.innerHTML;
            var targetValue = val.trim().localeCompare("Off")==0 ? true : false;

            switch(id){
                case "btnElement":
                    vm.boiler.isElementOn = targetValue;
                    break;
                case "btnPump":
                    vm.boiler.isPumpOn = targetValue;
                    break;
                case "btnBurst":
                    vm.boiler.isBurstOn = targetValue;
                    break;
            }

            this.change();
        }

        $scope.burst = function () {
            $scope.isBurstOn = !$scope.isBurstOn
            if ($scope.isBurstOn) {
                $scope.intervalFunction();
                $scope.interval = $interval($scope.intervalFunction, (1000 * vm.burstInterval) - (1000 * vm.burstTime));
            }
            else {
                $interval.cancel($scope.interval);
            }
        }

        $scope.intervalFunction = function () {
            vm.boiler.isElementOn = true;
            $scope.change();
            $timeout(function () {
                vm.boiler.isElementOn = false;
                $scope.change();

            }, (1000 * vm.burstTime));
        }



    }

    /*
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
    */


}());
