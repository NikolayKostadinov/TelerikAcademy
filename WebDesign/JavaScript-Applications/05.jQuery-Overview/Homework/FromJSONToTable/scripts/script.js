(function ($) {
    $(document).ready(function () {
        var table_obj = $('<table>');
        var trh = $('<tr>');
        trh.append($('<th>', { html: "№" }));
        trh.append($('<th>', { html: "First Name" }));
        trh.append($('<th>', { html: "Last Name" }));
        trh.append($('<th>', { html: "Grade" }));

        table_obj.append(($('<thead>').append(trh)));

        var records = [
            { fname: "Nikolay", lname: "Kostadinov", grade: "Ninja" },
            { fname: "Hristo", lname: "Grigorov", grade: "Ninja" },
            { fname: "Mariana", lname: "Grigorova", grade: "Jedi" },
            { fname: "Ceca", lname: "Meca", grade: "Rookie" },
            { fname: "Bate", lname: "Liubcho", grade: "Aprentist" },
            { fname: "Pesho", lname: "Troikata", grade: "shmatka" }
        ];

        $.each(records, function (index, item) {
            var table_row = $('<tr>', { id: index });
            var table_cell = $('<td>', { html: index + 1 });
            table_row.append(table_cell);
            $.each(item, function (index, prop) {
                if (!(prop instanceof Function || prop instanceof Object))
                    table_cell = $('<td>', { html: prop });
                    table_row.append(table_cell);
            })
            table_obj.append(table_row);
        })
        $("body").append(table_obj);
    })
})(jQuery);

