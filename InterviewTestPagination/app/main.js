﻿(function (angular) {
    "use strict";

    angular
        .module("todoApp")
        .directive("pagination", [pagination]);

    /**
     * Directive definition function of 'pagination' directive.
     * 
     * TODO: make it a reusable component (i.e. usable by any list of objects not just the Models.Todo model)
     * TODO: correctly parametrize scope (inherited? isolated? which properties?)
     * TODO: create appropriate functions (link? controller?) and scope bindings
     * TODO: make appropriate general directive configuration (support transclusion? replace content? EAC?)
     * 
     * @returns {} directive definition object
     */
    function pagination() {
        var directive = {
            restrict: "E", // example setup as an element only
            templateUrl: "app/templates/pagination.html",
            scope: {}, // example empty isolate scope
            controller: ["$scope", controller],
            link: link
        };

        function controller($scope) { }

        function link(scope, element, attrs) { }

        return directive;
    }

})(angular);

