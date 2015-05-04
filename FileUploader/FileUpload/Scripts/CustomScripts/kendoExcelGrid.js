function ExportToExcel(element, options) {

    // Create a datasource for the export data.
    var grid = element.data("kendoGrid");
    var serverPagingHistory = grid.dataSource.options.serverPaging;
    var pageSizeHistory = grid.dataSource.pageSize;
    var ds = new kendo.data.DataSource({
        data: grid.dataSource.data()
    });
    ds.query({
        aggregate: grid.dataSource._aggregate,
        filter: grid.dataSource._filter,
        sort: grid.dataSource._sort
    });

    // Define the data to be sent to the server to create the spreadsheet.
    data = {
        model: JSON.stringify((function () {
            var columns = grid.columns;
            for (var index in columns) {
                if (columns[index].command) {
                    columns.splice(index, 1);
                }
            }
            return columns;
        })()),
        data: JSON.stringify((function () {
            return ds._view;
        })()),
        title: options.excel.title
    };

    // Create the spreadsheet.
    $.ajax({
        type: "POST",
        url: options.excel.createUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data)
    })
    .done(function (e) {
        // Download the spreadsheet.
        window.location = kendo.format("{0}?title={1}",
            options.excel.downloadUrl,
            options.excel.title);
        grid.dataSource.options.serverPaging = serverPagingHistory;
    });
};