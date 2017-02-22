angular.module('moodDashboard')
.factory('MoodDataFactory', function ($http, $q, $timeout) {

	var urlBase = 'http://localhost:8084/api/mood/';

	var getMessages = function () {
		var deferred = $q.defer();

		$timeout(function () {
			$http.get("https://jsonplaceholder.typicode.com/posts/1")
			 .success(function (data) {
			 	deferred.resolve(data);
			 	console.log('albums (simple) returned to controller.', data);
			 })
			 .error(function () {
			 	deferred.reject("Failed to get data");
			 });
		}, 2000);

		return deferred.promise;
	};

	var getTeamByManagerId = function (mgrid) {
		var deferred = $q.defer();

		//$timeout(function () {
			$http.get(urlBase + '/rollupbymanager?mgrid=' + mgrid)
			 .success(function (data) {
			 	deferred.resolve(data);			 	
			 })
			 .error(function () {
			 	deferred.reject("Failed to get data");
			 });
		//}, 2000);

		return deferred.promise;
	};

	return {
		getMessages: getMessages,
		getTeamByManagerId: getTeamByManagerId
	};

});
