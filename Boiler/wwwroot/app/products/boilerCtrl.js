(function () {
    "use strict";
    angular
        .module("boilerManagement")
        .controller("BoilerCtrl",
                     ["$scope","$interval","$timeout",'$rootScope','$resource','appSettings', "boilerResource", BoilerCtrl]);


    function BoilerCtrl($scope, $interval, $timeout, $rootScope, $resource,appSettings, boilerResource) {
        var vm = this;

        $scope.gaugeInit = false;
        $scope.chartOptions = {
            width: 200, height: 200,
            redFrom: 90, redTo: 100,
            yellowFrom: 75, yellowTo: 90,
            minorTicks: 5
        };

        $scope.lineOptions = {
            hAxis: {
                title: 'Time'
            },
            vAxis: {
                title: 'Temp'
            },
            animation: {
                duration: 1000,
                easing: 'out',
            },
            legend: { position: 'none' }
        };
        $scope.lineData = new google.visualization.DataTable();
        $scope.lineData.addColumn('timeofday', 'Time of Day');
        $scope.lineData.addColumn('number', null);
        $scope.rootdate = new Date();

        var lastDate = new Date();

        lastDate = lastDate - 10000;

        $interval(function () {
            boilerResource.query(function (data) {
                vm.boiler = data;

                var dt = new Date();
                var seconds = (dt - lastDate) / 1000;

                if (seconds > 5) {
                    lastDate = dt;
                    if (!$scope.gaugeInit) {
                        $scope.chartData = google.visualization.arrayToDataTable([
                            ['Label', 'Value'],
                            ['Temp', 0]
                        ]);

                        var div = document.getElementById('chartDiv');
                        $scope.chart = new google.visualization.Gauge(div);

                        var lineDiv = document.getElementById('lineDiv');
                        $scope.lineChart = new google.visualization.LineChart(lineDiv);

                        $scope.gaugeInit = true;
                    }

                    $scope.lineData.addRow([[dt.getHours(), dt.getMinutes(), dt.getSeconds()], data.actualTemp]);
                    if ($scope.lineData.getNumberOfRows() > 1440) {
                        $scope.lineData.removeRow(0);
                    }
                    $scope.lineChart.draw($scope.lineData, $scope.lineOptions);

                    $scope.chartData.setValue(0, 1, data.actualTemp);
                    $scope.chart.draw($scope.chartData, $scope.chartOptions);

                    vm.boiler.actualTemp = data.actualTemp;
                }
                
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
            this.change();
        }



    }

}());
