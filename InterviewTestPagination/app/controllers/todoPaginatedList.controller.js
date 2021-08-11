(function (angular) {
    "use strict";

    angular
        .module("todoApp")
        .controller("todoPaginatedListController", todoPaginatedListController);

    function todoPaginatedListController($scope, todoPaginatedListService) {
        $scope.todos = [];

        todoPaginatedListService.getTodos().then(res => $scope.todos = res.data.rows);
    }

})(angular);