(function () {
    'use strict';

    angular
        .module('myApp')
        .factory('adminFactory', adminFactory);

    adminFactory.$inject = ['$http'];

    function adminFactory($http) {
        var service = {
            getData: getData,
            ShowTableEdit: ShowTableEdit,
            HiddenTableEdit: HiddenTableEdit,
            SaveImage: SaveImage,
            previewImg: previewImg,
            ShowHideBtnDelete: ShowHideBtnDelete,
        };

        return service;

        function getData() { }

        function ShowTableEdit() {
            $("#result_tr").css("visibility", "visible")
        }

        function HiddenTableEdit() {
            $("#result_tr").css("visibility", "hidden")
        }

        function SaveImage(sPath) {
            var data = new FormData();
            var files = $("#UploadImg").get(0).files;

            if (files.length > 0) {
                data.append("MyImages", files[0]);
            }
            data.append("sPath", sPath);

            $.ajax({
                url: "/Admin/UploadFile",
                type: "POST",
                processData: false,
                contentType: false,
                data: data,
                // Tắt đồng bộ hóa để nó upload trước rồi mới qua hành động #
                async: false,
                success: function (response) {
                    //code after success
                    $("#txtImg").val(response);
                    $("#imgPreview").attr('src', sPath + response);
                },
                error: function (er) {
                    alert(er);
                }
            });
        }

        function previewImg() {
            var el = document.getElementById('UploadImg');
            if (el.files && el.files[0]) {
                var FR = new FileReader();
                FR.addEventListener("load", function (e) {
                    document.getElementById("imgPreview").src = e.target.result;
                });
                FR.readAsDataURL(el.files[0]);
            }
        }

        function ShowHideBtnDelete() {
            var listCheckbox = $('.checked input[type=checkbox]')
            for (i = 0; i < listCheckbox.length; i++) {
                console.log(i)
                var id = listCheckbox[i].id.split("_")[1];
                var buttonId = "#btnDelete_" + id;
                $(buttonId).attr("disabled", true);
            }
        }

    }
})();