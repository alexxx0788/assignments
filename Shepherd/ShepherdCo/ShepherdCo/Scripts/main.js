$(document).ready(function() {
    LoadBalance();
    LoadStocks();
    setInterval(function () { LoadStocks(); }, 5000);
});

$('.load-stocks').click(function() {
    ReloadStocks();
});

function LoadBalance() {
    $.get("api/balance", function (data) {
        $(".balance").html(data);
    });
}


function ReloadStocks() {
    $.get("api/load", function (data) {
        LoadStocks();
    });
}

function LoadStocks() {
    $.get("api/stock", function (data) {
        $('#tableBody').empty();
        $(data).each(function (index, element) {
            if ($('#stock_price_' + element.StockId).length > 0) {
                $('#stock_price_' + element.StockId).text(element.Price);
            }
            $('#tableBody').append(GenerateTableRow(element));
        });
    });
}

function GenerateTableRow(element) {
    return '<tr><td>' + element.Company + '</td><td>' + element.Price + '</td><td><span class="' + GetChangeClassName(element.Change) + '">' + element.Change + '</span></td><td><span class="' + GetChangeClassName(element.ChangePersentage) + '">' + element.ChangePersentage + '</span></td><td>' + GenerateBuyButton(element.StockId, element.Amount) + '</td></tr>';
}

function GetChangeClassName(value) {
    return value > 0 ? 'green' : 'red';
}

function GenerateBuyButton(id,amount) {
    if (amount > 0) {
        return '<button href="/Home/Order/' + id + '" class="modal-link btn btn-success">Buy</button>';
    }
    return '';
}

function CloseModal() {
    $('#modal-container').modal('hide');
}

function UpdateBalance(login, balance, userId) {
    var user = {
        UserId: userId,
        Login: login,
        Balance: balance
    };

    var json = JSON.stringify(user);
    $.ajax({
        url: '/api/balance/'+userId,
        type: 'PUT',
        contentType: "application/json; charset=utf-8",
        data: json,
        success: function (result) {
            LoadBalance();
            CloseModal();
        }
    });
}

function BuyStock(stockId,amount) {
    var order = {
        stockId: stockId,
        amount : amount
    };
    var json = JSON.stringify(order);
    $.ajax({
        url: '/api/order',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: json,
        success: function (result) {
            $('#message').text(result.Data.Message);
            if (result.Data.Status == true) {
                LoadBalance();
                CloseModal();
            } else {
                $('#message').show();
                $('#message').attr('class', 'red');
            }
        }
    });
}


$(function() {
    // Initialize numeric spinner input boxes
    //$(".numeric-spinner").spinedit();

    // Initalize modal dialog
    // attach modal-container bootstrap attributes to links with .modal-link class.
    // when a link is clicked with these attributes, bootstrap will display the href content in a modal dialog.
    $('body').on('click', '.modal-link', function(e) {
        e.preventDefault();
        $('#message').hide();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });

    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function() {
        $('#modal-container').modal('hide');
    });

    //clear modal cache, so that new content can be loaded
    $('#modal-container').on('hidden.bs.modal', function() {
        $(this).removeData('bs.modal');
    });

    $('#CancelModal').on('click', function() {
        return false;
    });
});