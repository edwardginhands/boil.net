(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("boilerResource",
            ["$resource",
             "appSettings",
             boilerResource])

    function boilerResource($resource, appSettings) {
        /*
        return $resource(appSettings.serverPath + "/api/boiler", null,
            {
                'update': { method: 'PUT' }
            });
            */
        return $resource(appSettings.serverPath + "/api/boiler", {}, { query: { method: "GET", isArray: false }, update: { method: 'PUT' } });
    }


}());