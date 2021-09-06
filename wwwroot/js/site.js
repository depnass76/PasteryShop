// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.



/*alert("Hello there !");*/

$(document).ready(function()
{

    var theForm = $("#theForm");
    theForm.show();

    var button = $("#buyButton");

    button.on("click", function () {
        alert("Buying Item");
    });

    var productInfo = $("#ulFont li");
productInfo.on("click", function () {
       alert("You clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popupForm");

    $loginToggle.on("click", function() {
        $popupForm.fadeToggle(1000);
    });
});
