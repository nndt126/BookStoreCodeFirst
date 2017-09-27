function ShowHideBtnDelete() {
    var listCheckbox = $('.checked input[type=checkbox]')
    for (i = 0; i < listCheckbox.length; i++) {
        console.log(i)
        var id = listCheckbox[i].id.split("_")[1];
        var buttonId = "#btnDelete_" + id;
        $(buttonId).attr("disabled", true);
    }
}

var ConfirmDelete = function (AuthorID) {
    event.preventDefault();
    $("#hiddenAuthorID").val(AuthorID);
    $('#myModal').modal('show');
}

var CloseDialog = function () {
    $("#myModal").modal('hide');
}

var DeleteAuthor = function () {
    $("#loaderDiv").show();
    //$("#btnDelete_" + authorID).attr("disabled", false);
    var authorID = $("#hiddenAuthorID").val();
    $.ajax({
        type: "POST",
        url : "DeleteAjax",
        data: { AuthorID: authorID },
        success: function (result) {
        console.log(result);
        if (result) {
            $("#loaderDiv").hide();
            $("#myModal").modal("hide");

            $("#btnDelete_" + authorID).prop("disabled", true);
            var checkbox = "#check_" + authorID;
            $(checkbox).prop("checked", "checked");
            //location.reload();
        }
        else {
            alert("Fail to delete");
        }
    }
})
}


function SaveData()
{
    var el = document.getElementById('UploadImg');
    if (el.files && el.files[0]) {
        var sPath = "/assets/HinhAnhAuthor/";
        SaveImage(sPath);
    }
    document.getElementById("formDataAuthor").submit();
}

function UpdateData() {
    var el = document.getElementById('UploadImg');
    if (el.files && el.files[0]) {
        var sPath = "/assets/HinhAnhAuthor/";
        SaveImage(sPath);
    }
    document.getElementById("formDataAuthor").submit();
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



