(function () {
    "use strict";
    angular
        .module("boilerManagement")
        .controller("BoilerCtrl",
                     ["boilerResource",BoilerCtrl]);

    function BoilerCtrl(boilerResource) {
        var vm = this;

        //vm.boiler = { isElementOn: true};
        boilerResource.query(function (data) { vm.boiler = data; });
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
