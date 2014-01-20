var domModule = (function () {
    function appendChild(htmlElement, cssSelector)
    {
        var parent = [];
        parent.push(GetElementByCssSelector(cssSelector));
  
        if (parent.length > 0) {
            for (var i = 0; i < parent.length; i++) {
                parent[i].appendChild(htmlElement.cloneNode(true));
            }
        }
    }

    //function removeChild("ul", "li:first-child")
    //{

    //}

    //function addHandler("a.button", 'click', function () { alert("Clicked") })
    //{
    
    //}

    //function appendToBuffer("container", div.cloneNode(true))
    //{

    //}

    function GetElementByCssSelector(cssSelector)
    {
        var htmlElement = this.querySelectorAll(cssSelector);
        return htmlElement;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
    }
}())