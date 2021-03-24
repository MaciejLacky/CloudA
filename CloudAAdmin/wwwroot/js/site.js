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

function showEditClick(nr) {
    $.ajax({
        type: "POST",
        url: 'Home/ShowEditItem/'+nr,
        data: $("form").serialize(),
        success: function (data) {
            $("#EditFormArea").html(data).hide();
            $("#EditFormArea").html(data);
            $("#EditFormArea").html(data).fadeIn('slow');
        }
    });
};
var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");

        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
        document.getElementById("navbar").style.padding = "30px 10px";
        document.getElementById("logo").style.fontSize = "25px";
    } else {
        document.getElementById("navbar").style.padding = "80px 10px";
        document.getElementById("logo").style.fontSize = "35px";
    }
}