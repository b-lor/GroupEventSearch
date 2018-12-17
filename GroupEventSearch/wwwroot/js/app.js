'use strict'

var app = angular.module('App', [])

app.controller('AppController', ['$scope', '$filter', '$http', '$localStorage',
    function ($scope, $filter, $http, $localStorage) {

        $scope.init = function (location, category, startDate, endDate) {
            if (location !== undefined) {
                $scope.location = location
                $localStorage.location = location
            }
            else {
                $scope.location = $localStorage.location
            }
            if (category !== undefined) {
                $scope.category = category
                $localStorage.category = category
            }
            else {
                $scope.category = $localStorage.category
            }
            $scope.startDate = startDate == null ? $filter('date')(new Date('01/01/2018'), 'yyyy-MM-dd') : startDate
            $scope.endDate = endDate == null ?  $filter('date')(new Date(), 'yyyy-MM-dd') : endDate           
        }
    }])