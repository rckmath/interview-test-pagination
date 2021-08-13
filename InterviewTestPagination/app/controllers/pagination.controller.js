(function (angular) {
    "use strict";

    angular
        .module("todoApp")
        .controller("pagination", pagination);

    function pagination($scope, todoPaginatedListService) {
        $scope.gotoPage = gotoPage;
        $scope.updatePageSize = updatePageSize;

        function updatePageSize() {
            $scope.queryParams.currentPage = 1;

            todoPaginatedListService.getTodos($scope.queryParams).then(res => $scope.todo = res.data);
        }

        function gotoPage(page) {
            if (!page) { return; }

            if (page <= 0 || page > $scope.todo.totalPages) { return; }

            $scope.queryParams.currentPage = page;

            todoPaginatedListService.getTodos($scope.queryParams).then(res => $scope.todo = res.data);
        }
    }

})(angular);