'use strict';

angular.module('psWebMetricsService', []).factory('psWebMetricsService', [
    '$rootScope',
    function ($rootScope) {

        var hub = $.connection.tempHub;

        hub.client.broadcastMessage = function (time, temp) {

            $rootScope.$broadcast('psWebMetricsService-received-data-event',
                {
                    'time': time,
                    'temp': temp
                });

        };

        $.connection.hub.start()
            .done()
            .fail(function (data) {
                alert(data);
            }
        );

        return {

        };
    }
]);