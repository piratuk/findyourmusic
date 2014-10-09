
$(".jumbotron").find(".btn").click(function () {
    $(".jumbotron").fadeOut("fast", function () {
        $(".search-body").fadeIn();
    });
});

$("#addArtistButton").click(function () {
    if ($("#artistInput").val()) {
        $(".artistsList").append("<li class=\"list-group-item\">" + $("#artistInput").val() + "</li>");
        AddRemoveOnClickEvent($(".artistsList").children().last());
    }
    $("#artistInput").val("").focus();

});
$("#artistInput").keypress(function (e) {
    if (e.which == 13) {
        $("#addArtistButton").click();
    }
});
$("#searchButton").click(function () {
    $(".searchResults").fadeIn();
});

function AddRemoveOnClickEvent(element) {
    $(element).hover(function () {
        //show delete icon
    }, function () {
        //hide delete icon
    });
    $(element).click(function () {
        $(this).remove("span");
        $(this).remove();
    });
}

