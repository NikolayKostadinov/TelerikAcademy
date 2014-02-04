var Selection = {
    init: function () {
        this._selectedElement = {};
    },
    get: function () {
        return this._selectedElement
    },
    set: function (selectedElement) {
        this._selectedElement = selectedElement;
    },

    append: function () {
        var addintionalElement = $(document.createElement('div'));
        addintionalElement.attr = this._selectedElement.attr;
        addintionalElement.text("Appended");
        addintionalElement.on("click", onElementClick);
        this._selectedElement.after(addintionalElement);
    },

    prepend: function () {
        var addintionalElement = $(document.createElement('div'));
        addintionalElement.attr = this._selectedElement.attr;
        addintionalElement.attr["style", "background-color:none;"];
        addintionalElement.text("Prepended");
        addintionalElement.on("click", onElementClick);
        this._selectedElement.before(addintionalElement);
    }
}

var selectedElement = {};

$(document).ready(function () {
    $("#wrapper div, button").on("click", onElementClick);
    selectedElement = Object.create(Selection);
    selectedElement.init();
});

function onElementClick() {
    var jQObj = $(this);
    if (jQObj.is("div")) {
        selectedElement.set(jQObj);
        $('#wrapper div').attr("style", "baskground-color:none");
        jQObj.attr("style", "background-color: lightblue");
    } else if (jQObj.is("button")) {
        if (jQObj.attr("id") == "prepend") {
            if (selectedElement && selectedElement.get()) {
                selectedElement.prepend();
            }
        } else if (jQObj.attr("id") == "append") {
            if (selectedElement && selectedElement.get()) {
                selectedElement.append();
            }
        }
    }
}