kendo.culture("en-IE");

function error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        alert(message);
    }
}

//function exportGridData (sender) {

//    var gridDiv = sender.parents('div[class~="k-grid"]').first(); // да точно така е!!!
//    var grid = gridDiv.data("kendoGrid");

//    $.ajax({
//        type: "POST",
//        url: "/Download/ExportWithOpenXML",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify({
//            html: grid.table.context.innerHTML
//        }),
//        success: function (data) {
//        },
//        error: function (result) {
//            alert('Oh no: ' + result.responseText);
//        },
//        async: false
//    });
//}