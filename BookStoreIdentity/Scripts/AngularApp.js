var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);

(function (myApp) {
    "use strict";

    myApp.controller('bookController', bookController);
    bookController.$inject = ['$scope', '$http', 'bookService', 'authorService', 'adminFactory'];

    function bookController($scope, $http, bookService, authorService, adminFactory) {
        $scope.selectedAuthor = null;
        $scope.ListAuthor = [];
        var sPath = "/assets/HinhAnhBook/";
        adminFactory.HiddenTableEdit();
        getAllBooks();
        getListAuthor();

        function getAllBooks() {
            bookService.getData().then(function (result) {
                $scope.BooksJson = result.data;
            }, function (error) {
                console.log(error);
            });
        }

        $scope.getData = function () {
            getAllBooks();
        };

        function getListAuthor() {
            authorService.getListAuthor().then(function (result) {
                $scope.ListAuthor = result.data;
            }, function (error) { console.log(error) });
        }

        //******=========Get Single Book by ID=========******
        $scope.getBookById = function (data) {
            adminFactory.ShowTableEdit();
            $("#imgPreview").removeAttr('src');
            bookService.GetBookByID(data).then(function (result) {
                $scope.data = result.data;
                $("#imgPreview").attr('src', sPath + $scope.data.Image);
            }, function (error) {
                console.log(error);
            })
        }

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
        $scope.editBook = function (data) {

            var el = document.getElementById('UploadImg');
            if (el.files && el.files[0]) {
                adminFactory.SaveImage(sPath);
                $scope.data.Image = $("#txtImg").val();
                $('#UploadImg').val('');
            }
            bookService.AddBook($scope.data).then(function (result) {
                //$scope.Books = result;
                $scope.data.Image = null;
                alert('Successfull');
                $scope.getData();
                adminFactory.HiddenTableEdit();
            }, function (error) { console.log(error) });
           
        };

        $scope.deletedBook = function (data) {
            bookService.DeleteBook(data).then(function (result) {
                //$scope.Books = result.data;
                alert('Delete Successfull');
                $scope.getData();
            }, function (error) {
                console.log(error);
            })
        }

        //$scope.deletedBook = function (data) {
        //    var IsConf = confirm('You are about to delete ' + data.Name + '. Are you sure?');
        //    if (IsConf) {
        //        $http.post('/Book/DeleteBook', data).then(function (result) {
        //            $scope.Books = result;
        //            alert('Delete Successfull');
                    
        //        }, function (error) { console.log(error) })
        //    }
        //}

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;   //set the sortKey to the param passed
            $scope.reverse = !$scope.reverse; //if true make it false and vice versa
        };
    }

})(myApp);
