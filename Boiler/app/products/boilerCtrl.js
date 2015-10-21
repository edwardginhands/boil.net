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

        $scope.gaugeInit = false;
        $scope.chartOptions = {
            width: 100, height: 100,
            redFrom: 90, redTo: 100,
            yellowFrom: 75, yellowTo: 90,
            minorTicks: 5
        };

        $scope.$on('statusService-received-data-event', function (event, args) {
            if (args.element != vm.boiler.isElementOn || args.pump != vm.boiler.isPumpOn) {

                vm.boiler.isElementOn = args.element;
                vm.boiler.isPumpOn = args.pump;
                $scope.$apply();
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
            $scope.chartData.setValue(0, 1, Math.round(args.temp));
            $scope.chart.draw($scope.chartData, $scope.chartOptions);

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
