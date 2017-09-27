(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('bookService', bookService);

    bookService.$inject = ['$http'];

    function bookService($http) {
        var service = {
            getData: getData,
        };

        return service;

        function getData() {
            var result = $http.get('/Book/AdminGetAllBooksJson');
            return result;
        }

        
    }
})();