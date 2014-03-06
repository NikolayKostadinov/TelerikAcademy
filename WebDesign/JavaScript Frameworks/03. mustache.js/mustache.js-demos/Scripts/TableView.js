/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var TableView = Class.create({
        init: function (itemsSource, colsCount, rowsCount) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.rowsCount = rowsCount;
            this.colsCount = colsCount;
        },
        render: function (template) {
            var table = document.createElement("table");
            var count = 0;
            for (var row = 0; row < this.rowsCount; row++) {
                var tr = document.createElement("tr");
                for (var col = 0; col < this.colsCount; col++, count++) {
                    var td = document.createElement("td");
                    if (count < this.itemsSource.length) {
                        td.innerHTML = template(this.itemsSource[count]);
                        tr.appendChild(td);
                    }
                }
                table.appendChild(tr);
            }
            return table.outerHTML;
        }
    });

    c.getTableView = function (itemsSource, colsCount, rowsCount) {
        return new TableView(itemsSource, colsCount, rowsCount);
    }
}(controls || {}));