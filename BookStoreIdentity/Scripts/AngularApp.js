var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);

(function (myApp) {
    "use strict";

    myApp.controller('bookController', bookController);
    bookController.$inject = ['$scope', '$http', 'bookService', 'adminFactory'];

    function bookController($scope, $http, bookService, adminFactory) {
        $scope.selectedAuthor = null;
        $scope.ListAuthor = [];
        adminFactory.HiddenTableEdit();
        getAllBooks();
        getListAuthor();

        function getAllBooks() {
            bookService.getData().then(function (result) {
                $scope.BooksJson = result.data;
            }, function(error) {console.log(error)})
        }

        $scope.getData = function () {
            getAllBooks();
        };

        function getListAuthor() {
            $http.get('/Author/AdminGetAllAuthorsJson').then(function (result) {
                $scope.ListAuthor = result.data;
            }, function (error) { console.log(error) })
        }

        //******=========Get Single Book by ID=========******
        $scope.getBookbyId = function (data) {
            adminFactory.ShowTableEdit();
            $("#imgPreview").removeAttr('src');
            $http.get('/Book/GetBookByID/' + data.ID)
            .then(function (result) {
                //debugger;

                $scope.data = result.data;
                var sPath = "/assets/HinhAnhBook/";
                $("#imgPreview").attr('src', sPath + $scope.data.Image);
                //getallData();
            }, function (error) { console.log(error) })
        };

        $scope.addNew = function () {
            $scope.data = {
                ID: 0,
                //Prices: 0,
                Image: null,
                Description: null,
                IsDeleted: false,
            };
            $("#imgPreview").removeAttr('src');
            adminFactory.ShowTableEdit();
        }

        $scope.hiddenTableEdit = function () {
            adminFactory.HiddenTableEdit();
        }

        //******=========Save Information=========******
        $scope.editBook = function () {

            var el = document.getElementById('UploadImg');
            if (el.files && el.files[0]) {
                var sPath = "/assets/HinhAnhBook/";
                adminFactory.SaveImage(sPath);
                $scope.data.Image = $("#txtImg").val();
                $('#UploadImg').val('');
            }
            $http.post('/Book/AddBook/', $scope.data)
            .then(function (result) {
                $scope.Books = result;
                $scope.data.Image = null;
                alert('Successfull');
                $scope.getData();
                adminFactory.HiddenTableEdit();
            }, function (error) { console.log(error) })
        };

        $scope.deletedBook = function (data) {
            var IsConf = confirm('You are about to delete ' + data.Name + '. Are you sure?');
            if (IsConf) {
                $http.post('/Book/DeleteBook', data).then(function (result) {
                    $scope.Books = result;
                    alert('Delete Successfull');
                    $scope.getData();
                }, function (error) { console.log(error) })
            }
        }

        

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;   //set the sortKey to the param passed
            $scope.reverse = !$scope.reverse; //if true make it false and vice versa
        };
    }

})(myApp);
