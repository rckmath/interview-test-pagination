(function (angular) {
    "use strict";

    angular
        .module("todoApp")
        .controller("todoPaginatedListController", todoPaginatedListController);

    function todoPaginatedListController($scope, todoPaginatedListService) {
        $scope.key;
        $scope.todo = {};
        $scope.queryParams = {};
        $scope.ordering = 'desc';

        $scope.orderBy = orderBy;
        $scope.getOrderingClass = getOrderingClass;

        todoPaginatedListService.getTodos().then(res => $scope.todo = res.data);

        /**
         * If the orderBy key is the same, inverts the query ordering direction (means a second click at the same table head)
         * @param {any} key Table head which will determine the key for data ordering
         */
        function invertOrdering(key) {
            if (key == $scope.key) {
                $scope.ordering = $scope.ordering === 'desc' ? 'asc' : 'desc';
            } else {
                $scope.ordering = 'asc';
            }
        }

        /**
         * 
         * @param {any} key
         */
        function getOrderingClass(key) {
            if (key == $scope.key) {
                return $scope.ordering === 'desc' ? 'arrow-down' : 'arrow-up';
            }

            return 'arrow-invisible';
        }

        /**
         * Calls getTodos API with new ordering parameters
         * @param {any} key Table head which will determine the key for data ordering
         */
        function orderBy(key) {
            if (!$scope.key)
                $scope.key = key;

            invertOrdering(key);

            $scope.key = key;
            $scope.queryParams.orderBy = $scope.key;
            $scope.queryParams.ordering = $scope.ordering;
            $scope.queryParams.currentPage = 1;

            todoPaginatedListService.getTodos($scope.queryParams).then(res => $scope.todo = res.data);
        }
    }

})(angular);