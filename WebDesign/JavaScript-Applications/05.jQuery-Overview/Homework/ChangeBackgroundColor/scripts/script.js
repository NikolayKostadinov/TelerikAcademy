(function () {
    $(document).ready(function () {
        $('#color').on("change", changeColorPicker);
    });

    function changeColorPicker()
    {
        $('body').attr("style", "background-color: " + $(this).prop("value"));

    }
})(jQuery);


