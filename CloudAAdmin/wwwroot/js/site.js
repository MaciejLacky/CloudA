// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(".editItemRadio").change(function () {
        itemUpdate();
    });

    function itemUpdate() {
        $.ajax({
            type: "POST",
            url: 'Home/ShowEditItem',
            data: $("form").serialize(),
            success: function (data) {
                $("#EditFormArea").html(data);
            }
        });
    };

   
});
