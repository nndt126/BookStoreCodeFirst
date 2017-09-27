(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('authorService', authorService);

    authorService.$inject = ['$http', '$q'];

    function authorService($http, $q) {
        var service = {
            getListAuthor: getListAuthor,
        };

        return service;

        function getListAuthor() {
            var q = $q.defer();
            $http.get('/Author/AdminGetAllAuthorsJson').then(function (response) {
                var result = { isSuccess: true, data: response.data }
                q.resolve(result);
            }, function (error) {
                //var result = { isSuccess: false, data: error };
                q.reject(error);
            });
            return q.promise;
        }
    }
})();