var domModule = (function () {
    var buffer = {};
    var MAX_LENGHT_TO_APPEND = 100;
    function AddChild(htmlElement, cssSelector)
    {
        var parentNodes = document.querySelectorAll(cssSelector);
        for (var i = 0; i < parentNodes.length; i++) {
            parentNodes[i].appendChild(htmlElement.cloneNode(true));
        }
    }

    function DellChild(parentNodeSelector, nodesToRemoiveSelector)
    {
        var parentNodes = document.querySelectorAll(parentNodeSelector);
        if (parentNodes.length > 0) {
            for (var i = 0; i < parentNodes.length; i++) {
                var nodesToRemove = parentNodes[i].querySelectorAll(nodesToRemoiveSelector);
                if (nodesToRemove.length > 0)
                {
                    for (var j = 0; j < nodesToRemove.length; j++) {
                        nodesToRemove[j].parentElement.removeChild(nodesToRemove[j]);
                    }
                }
            }
        }
    }

    function addHandler(htmlElementSelector, eventType, functionToCall)
    {
        var nodesToAddHandler = document.querySelectorAll(htmlElementSelector);
        for (var i = 0; i < nodesToAddHandler.length; i++) {
            nodesToAddHandler[i].addEventListener(eventType, functionToCall);
        }
    }

    function AddToBuffer(htmlElementSelector, htmlElement)
    {
        if (!buffer[htmlElementSelector]) {
            buffer[htmlElementSelector] = document.createDocumentFragment();
        }
        var newElement = null;
        if (htmlElement instanceof HTMLElement)
        {
             newElement = htmlElement;
        } else {
             newElement = document.createElement(htmlElement);
        }

        if (newElement) {
            buffer[htmlElementSelector].appendChild(newElement);
        }

        if (buffer[htmlElementSelector].childNodes.length >= MAX_LENGHT_TO_APPEND) {
            var nodes = document.querySelectorAll(htmlElementSelector);
            for (var i = 0; i < nodes.length; i++) {
                nodes[i].appendChild(buffer[htmlElementSelector]);
            }
        }
    }

        return {
            appendChild: AddChild,
            removeChild: DellChild,
            addHandler: addHandler,
            appendToBuffer: AddToBuffer,
            }    
})();
var div = document.createElement("div");
//appends div to #wrapper
domModule.appendChild(div, "#wrapper");
//removes li:first-child from ul
domModule.removeChild("ul","li:first-child"); 
//add handler to each a element with class button
domModule.addHandler("a.button", 'click',        
                     function () { alert("Clicked") });
div.innerHTML = 'first time';
for (var i = 0; i < 100; i++) {
    domModule.appendToBuffer(".container", div.cloneNode(true));
}
div.innerHTML = 'second time';
for (var i = 0; i < 20; i++) {
    domModule.appendToBuffer(".container", div.cloneNode(true));
}
//domModule.appendToBuffer("#main-nav ul", navItem);