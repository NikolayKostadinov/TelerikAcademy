function add_new_user() {
    var wnd = $("#AddNewUser").kendoWindow({
        modal: true,
    }).data("kendoWindow");
    wnd.center().open();
}

function close_window(arg) {
    $("#cancel").click(function () {
        window.close();
    });
}

function dataBound() {
    this.expandRow(this.tbody.find("tr.k-master-row").first());
}

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
        $("#validation_summary").text(message);
        $("#users").data('kendoGrid').dataSource.read();
        $("#users").data('kendoGrid').refresh();

    }
}

function onAddNewUserOpen(e) {
    e.sender.center()
}

function onAddNewUserError(e)
{
    alert('AddNewUserError');
}

function onResetPasswordClick(ev) {
    ev.preventDefault();

    var aft = sendAntiForgery();
    var dataItem = this.dataItem($(ev.currentTarget).closest("tr"));
    $.ajax({
        type: "POST",
        url: location.protocol + '//' + location.host + '/UserAdministration/ResetPassword',
        data: { "userId": dataItem.Id, "redirect": location.toString(), "__RequestVerificationToken": aft.__RequestVerificationToken }
    })
        .done(function (msg) {
            var successMessageContaineer = $("#text-succes");
            successMessageContaineer.text("Паролата беше ресетната успешно! Новата парола на потребителя е 12345678.");
            successMessageContaineer.show();
            successMessageContaineer.fadeOut(7000);

        })
        .fail(
            function (msg) {
                var failMessageContainer = $("#fail-succes");
                failMessageContainer.text("Възникна грешка при опит за ресет на парола!");
                failMessageContainer.show();
                failMessageContainer.fadeOut(7000);
            }
        );
}

(function (ev) {
    window.addEventListener('click', OnClick, false);
    function OnClick(ev) {
        if ($("#validation_summary").text() != "") {
            $("#validation_summary").html("<ul><li style='display:none'></li></ul>");
            ev.errors = null;
        }
    }
})()