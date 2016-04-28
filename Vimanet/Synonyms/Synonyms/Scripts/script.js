//After loading the page, render synonyms groups
$(window).load(function () {
    LoadSynonyms();
});
//assign an event on the button, for posting a synonym
$('#tbPost').click(function () {
    PostSynonym();
});
// loading synonyms. Clear the synonyms-list block, request a banch of synonyms from the server and render it.
function LoadSynonyms() {
    $.get("api/synonyms", function (data) {
        $("#synonym-list").html('');
        $.each(data, function (index, value) {
            RenderSynonymRow(value);
        });
    });
}
//Render one row of synonyms group
function RenderSynonymRow(item) {
    var row = document.createElement('div');
    $(row).append("<div class='term'>" + item.Term + "</div>");
    $(row).append(RenderListOfSynonyms(item.Synonyms));
    $(row).addClass("row").appendTo($("#synonym-list"));
}
//Render a list of synonyms for one term
function RenderListOfSynonyms(synonym) {
    var list = document.createElement('div');
    $(list).addClass("list");
    var items = synonym.split(',');
    for (var i = 0; i < items.length; i++) {
        $(list).append("<span>" + items[i] + "</span>");
    }
    return list;
}
//Post a synonym via API
function PostSynonym() {
    if ($('#tbTerm').val() == '' || $('#tbSynList').val() == '') {
        alert("Please, fill all fields and then post a synonym");
        return;
    }
    var synonym = {
        Term: $('#tbTerm').val(),
        Synonyms: $('#tbSynList').val()
    };
    $.ajax({
        url: '/api/synonyms',
        type: 'POST',
        data: JSON.stringify(synonym),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            LoadSynonyms();
            $('#tbTerm').val('');
            $('#tbSynList').val('');
        }
    });
}