
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
    var query = "/Home/GetSimilarArtists?";
    for (var i = 0; i < $(".artistsList").children().length; i++) {
        query += "artistName=" + $($(".artistsList").children()[i]).text() + "&";
    }
    $.getJSON(query, function (data) {
        var results = data;

        var row = $(".searchResults").children(".row");
        for (var i = 0; i < results.length; i++) {
            var artist = results[i];
            var at = $("<div></div>", {
                "class": "col-sm-6 col-md-4"
            }).appendTo(row);
            var t = $("<div></div").addClass("thumbnail").appendTo(at);
            var im = $("<div></div>").addClass("img-wrapper").append("<img src=\"" + artist.ImageUrl + "\" alt=\"...\">").appendTo(t);
            var c = $("<div class=\"caption\"></div>").appendTo(t);
            $("<a href=\"" + artist.Url + "\" target=\"_blank\">" + "<h3>" + artist.Name + "</h3>" + "</a>").appendTo(c);
            $("<p>" + artist.Description + "</p>").appendTo(c);
            var p = $("<div></div>").addClass("progress").appendTo(t);
            var pb = $("<div aria-valuenow=" + artist.PercentageSimilarity + ">" + Math.round(artist.PercentageSimilarity) + "</div>").addClass("progress-bar").attr("role", "progressbar").attr("aria-valuemin", "0").attr("aria-valuemax", "100").attr("style", "width: " + artist.PercentageSimilarity + "%; font-size: 72px; line-height: 25px").appendTo(p);
        }
        $(".searchResults").fadeIn();
    });
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

