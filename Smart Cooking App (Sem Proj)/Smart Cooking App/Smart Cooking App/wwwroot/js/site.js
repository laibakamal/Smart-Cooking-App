//Why jQuery methods are inside a document ready event
//This is to prevent any jQuery code from running before the document is finished loading (is ready).

$(document).ready(function () {

    $('#see-more').click(function () {
        $.get("/Userr/Album", function (result) {
            $('#partialPlaceHolder').append(result);
        });
    });
});




$(document).ready(function () {

    $('#admin-see-more').click(function () {
        $.get("/Admin/AdminAlbum", function (result) {
            $('#partialPlaceHolder').append(result);
        });
    });
});
