'use strict';

angular.module('psGauge').directive('psGauge', [
    'psWebMetricsService',
    function (psWebMetricsService) {
        return {
            scope: {metric: '@metric', title: '@title'},
            templateUrl: 'common/psGaugeTemplate.html',
            link: function (scope, el, attrs) {

                scope.initialized = false;
                scope.options = {
                    width: 100, height: 100,
                    redFrom: 90, redTo: 100,
                    yellowFrom: 75, yellowTo: 90,
                    minorTicks: 5
                };

                scope.$on('psWebMetricsService-received-data-event', function (evt, data) {

                    if (!scope.initialized) {
                        scope.data = google.visualization.arrayToDataTable([
                            ['Label', 'Value'],
                            [scope.title, 0]
                        ]);

                        scope.chart = new google.visualization.Gauge(el[0]);
                        scope.initialized = true;
                    }
                    scope.data.setValue(0, 1, Math.round(data[scope.metric]));
                    scope.chart.draw(scope.data, scope.options);
                });
            }
        };
    }]);