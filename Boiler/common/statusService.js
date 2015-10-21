'use strict';

angular.module('statusService', []).factory('statusService', [
    '$rootScope',
    function ($rootScope) {

        var hub = $.connection.tempHub;

        hub.client.broadcastMessage = function (time, temp, element, pump) {

            $rootScope.$broadcast('statusService-received-data-event',
                {
                    'time': time,
                    'temp': temp,
                    'element': element,
                    'pump': pump,
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