(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('bookService', bookService);

    bookService.$inject = ['$http','$q'];
    /*Sử dụng Promise $q để xử lí bất đồng bộ */
    function bookService($http, $q) {
        var service = {
            getData: getData,
            GetBookByID: GetBookByID,
            AddBook: AddBook,
            DeleteBook: DeleteBook,
        };

        function getData() {
            var q = $q.defer();
            $http.get('/Book/AdminGetAllBooksJson').then(function (response) {
                var result = { isSuccess: true, data: response.data }
                q.resolve(result);
            }, function (error) {
                //var result = { isSuccess: false, data: error };
                q.reject(error);
            });
            return q.promise;
        }

        function GetBookByID(data) {
            var q = $q.defer();
            $http.get('/Book/GetBookByID/' + data.ID).then(function (response) {
                var result = { isSuccess: true, data: response.data }
                q.resolve(result);
            }, function (error) {
                q.reject(error);
            });
            return q.promise;
        }

        function AddBook(data) {
            var q = $q.defer();
            $http.post('/Book/AddBook/', data).then(function (response) {
               var result = { isSuccess: true, data: response.data }
               q.resolve(result);
           }, function (error) {
               q.reject(error);
           });
            return q.promise;
        }

        function DeleteBook(data) {
            var q = $q.defer();
            var IsConf = confirm('You are about to delete ' + data.Name + '. Are you sure?');
            if (IsConf) {
                $http.post('/Book/DeleteBook', data).then(function (response) {
                    //var result = { isSuccess: true, data: response.data }
                    q.resolve(response);

                }, function (error) {
                    q.reject(error);
                });
            }
            return q.promise;
        }

        return service;

        //function getData() {
        //    var result = $http.get('/Book/AdminGetAllBooksJson');
        //    return result;
        //}

        
    }
})();