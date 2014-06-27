function onError(e) {
    var inputFilesInfo = getFileInfo(e);
    var messages = "";
    if ((e.XMLHttpRequest.status == 500) || (e.XMLHttpRequest.status == 0)) {
        for (var id in inputFilesInfo) {
            messages += "Файлът \"" + inputFilesInfo[id].text
                        + "\" с размер: " + inputFilesInfo[id].size + "KB"
                        + " не може да бъде качен." +
                        ((inputFilesInfo[id].size > 1024) ? "<br /> Размера на файла не може да надвишава 10MB!<br />" : "<br />");
        }
    } else if (e.XMLHttpRequest.status == 200) {
        messages = e.XMLHttpRequest.responseText;
    }
    $("#errors").html(messages);
    $("#summary").html("");
    $("#grid-result").html("");


}
function onSuccess(e) {
    var fileId = e.response.fileId;
    $("#grid-result").text = "";
    $("#grid-result").kendoGrid({
        dataSource: {
            type: "jsonp",
            transport: {
                read: {
                    url: location.protocol + '//' + location.host + "/FileUppload/GetUploadResults?fileId=" + fileId,
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                model: {
                    id: "Id",
                    fields: {
                        RowNumber: { type: "string" },
                        Message: { type: "string" },
                        Status: { type: "string" },
                    }
                }
            },
        },
        dataBound: onDataBound,
        rowTemplate: '<tr class="#:Status==\"3\"? \"pink\" : Status==\"2\"? \"yellow\" :\"white\"#" data-uid="#= uid #">' +
                        '<td>#:RowNumber#</td>' +
                        '<td>#:Message#</td>' +
                        '<td class="#:Status==\"3\"? \"error\" : Status==\"2\"? \"warning\" :\"ok\"#" style=\"padding-left: 30px;\">' +
                        '#:Status==\"3\"? "Грешки" : Status==\"2\"? "Предупреждение" : "Ok"#</td>' +
                        '</tr>',
        height: 500,
        scrollable: true,
        columns: [{ field: 'RowNumber', title: 'Ред №', width: 60 },
                  { field: 'Message', title: 'Съобщение' },
                  { field: 'Status', title: 'Статус', width: 155, groupFooterTemplate: "Всичко: #=count#", groupHeaderTemplate: "Статус: #= value==3?'Грешки': value==2 ? 'Предупреждения' : 'Ok' #- #= count#" }, ],
    });
}

function onDataBound(arg) {
    var data = arg.sender._data;
    var result = [{},
        { message: 'Приети', count: 0 },
        { message: 'Предупреждения', count: 0 },
        { message: 'Грешки', count: 0 }, ];

    for (var i in data) {
        result[data[i].Status].count++;
    }

    $('#summary').html(
        (result[1].count > 0 ? '<div><label id="status1" class="ok summary"></label></div>' : '<input type="hidden" id = "status1" />') +
        (result[2].count > 0 ? '<div class="yellow"><label id="status2" class="warning summary"></label></div>' : '<input type="hidden" id = "status2" />') +
        (result[3].count > 0 ? '<div class="pink"><label id="status3" class="error summary"></label></div>' : '<input type="hidden" id = "status3" />'));

    for (var j = 1; j < result.length; j++) {
        $('#status' + j).text(result[j].message + " - " + result[j].count);
    }
}

function getFileInfo(e) {
    return $.map(e.files, function (file) {
        var info = { "text": "", "size": 0 };
        info.text = file.name;
        // File size is not available in all browsers
        if (file.size > 0) {
            info.size = +Math.ceil(file.size / 1024);
        }
        return info;
    });
}

var onSelect = function (e) {
    $("#errors").html("");
    $.each(e.files, function (index, file) {
        var ok = file.extension == ".txt"
                 || file.extension == ".TXT";

        if (!ok) {
            e.preventDefault();
            alert("Моля качвайте само текстови файлове с разширение \".txt\"!");
        }
    });
};