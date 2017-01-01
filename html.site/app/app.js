var plasticonnectApp = angular.module('plasticonnectApp', ['ngRoute']);
				
plasticonnectApp.controller('HomeCtrl', function($scope){
			$scope.test='this is a test';
});

plasticonnectApp.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/home', {
        templateUrl: 'app/components/home/home-index.html',
        controller: 'HomeCtrl'
      }).
/*
      when('/requisition', {
        templateUrl: 'app/components/requisition.html',
        controller: 'RequisitionCtrl'
      }).
      when('/products', {
        templateUrl: 'app/components/products.html',
        controller: 'ProductsCtrl'
      }).
      when('/hisotry', {
        templateUrl: 'app/components/history.html',
        controller: 'HistoryCtrl'
      }).
	  */
      otherwise({
        redirectTo: '/home'
      });
  }]);