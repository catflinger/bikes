﻿angular.module('bikesApp')

.controller('routeListController', ["$scope", "$state", "model", "Admin", function (scope, state, model, Admin) {
    scope.data = model.data;

    scope.add = function () {
        state.go("routeAdd", { id: 0 });
    };

    scope.refresh = function () {
        Admin.refresh(function () {
            model.refresh();
            state.go("routeList");
        });
    };

}])

.controller('routeEditController', ["$scope", "$state", "$stateParams", "model", "Route", function (scope, state, stateParams, model, Route) {

    if (stateParams.id == 0) {
        scope.route = new Route();
    } else {
        scope.route = Route.get({ id: stateParams.id });
    }

    scope.saveForm = function () {
        scope.route.$save(function () {
            model.refresh();
            state.go("routeList");
        });
    };

    scope.deleteRoute = function () {
        scope.route.$trash(function () {
            model.refresh();
            state.go("routeList");
        });
    };

    scope.cancel = function () {
        state.go("routeList");
    };

}]);