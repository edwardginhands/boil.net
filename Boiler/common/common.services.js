(function () {
    "use strict";

    angular
        .module("common.services",
                    ["ngResource"])
        .constant("appSettings",
            {
                //serverPath: "http://localhost:56854"
                serverPath: window.location.origin
            });
}());