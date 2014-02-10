/// <reference path="jquery-2.1.0.js" />
(function ($) {
    $.fn.treeview = function () {
        $('ul', this).css("display","none");

        this.on("click", "a", function (event) {
            $(this).next().toggle();
            $(this).parent().toggleClass('opened');
            event.preventDefault();
        })

    }
    return this;
})(jQuery)