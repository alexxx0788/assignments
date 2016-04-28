$('#inSearch').click(function () {
    var title = $('#inTitle').val();
    $.get("Imdb/Movie/GetMovies", { title: title }, function (data) {
        $("#movie-list").after(data);
        jumpToPageBottom();
    });
});

function jumpToPageBottom() {
    $('html, body').scrollTop($(document).height() - $(window).height());
}
