    var Slider = {
        init: function (selector, content) {
            this._content = content;
            this._index = 0;
            this._hostingDiv = $(selector);
        },
        next: function () {
            this._index++;
            if (this._index > this._content.length - 1) {
                this._index = 0;
            }
            this.render();
        },
        prev: function () {
            this._index++;
            if (this._index > this._content.length - 1) {
                this._index = 0;
            }
            this.render();
        },

        render: function () {
            this._hostingDiv.html(this._content[this._index]);
            this._hostingDiv.children().attr("style", "clear: both; margin-left:20px; margin-right:auto;");
        }
    };

var content = ["<h3>Picture1</h3><img src='images/1.jpg' style='width:500px;'>",
                "<h3>Picture2</h3><img src='images/2.jpg' style='width:500px;'>",
                "<h3>Picture3</h3><img src='images/3.jpg' style='width:500px;'>",
                "<h3>Picture4</h3><img src='images/4.jpg' style='width:500px;'>",
                "<h2>H2 Title1</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                "<h2>H2 Title2</h2><div>Lorem ipsum dolor sit amet <ul><li>list item</li><li>list item2</li></ul></div>",
                "<h2>H2 Title3</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                "<h2>H2 Title4</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                "<h2>H2 Title5</h2><div>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facere, nesciunt, dolor, nostrum ipsum alias voluptatem quasi quas atque illum ad blanditiis iusto sint consequatur totam voluptates non aspernatur. Iure, eum.</div>",
                "<img src='images/10.jpg'><h4>Tree</h4>"];

var mySlider = {};

$(document).ready(function () {
    mySlider = Object.create(Slider);
    mySlider.init("#content", content);
    mySlider.render();

    $(".button").on("click", onButtonClick);

    (function () {
        setInterval(function () {
            mySlider.next();
        }, 5000)
    })();
});

function onButtonClick() {
    var jQthis = $(this);
    if (jQthis.attr("id") == "next") {
        mySlider.next();
    } else if (jQthis.attr("id") == "prev") {
        mySlider.prev();
    }
}