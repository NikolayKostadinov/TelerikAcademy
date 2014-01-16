//Random width and height between 20px and 100px
//Random background color
//Random font color
//Random position on the screen (position:absolute)
//A strong element with text "div" inside the div
//Random border radius
//Random border color
//Random border width between 1px and 20px
function LoadDivs() {
    var docFragment = document.createDocumentFragment();
    docFragment.appendChild(GenerateDivs(100));
    document.body.appendChild(docFragment);
}

function GenerateDivs(numberOfDivs) {
    var docFragment = document.createDocumentFragment();
    for (var i = 0; i < numberOfDivs; i++) {
        var width = GetRandomBetween(1, 300);
        var height = GetRandomBetween(1, 300);
        var backgroundColor = GetColor();
        var fontColor = GetColor();
        var position = GetCoord(height, width);
        var borderRadius = GetRandomBetween(0, Math.min(height, width));
        var borderColor = GetColor();
        var borderWidth = GetRandomBetween(1, 20)
        var div = ConstructDiv(width, height, backgroundColor, fontColor, position, borderRadius, borderColor, borderWidth);
        var strong = document.createElement("strong");
        strong.innerHTML = "div";
        div.appendChild(strong.cloneNode(true));
        docFragment.appendChild(div.cloneNode(true));
    }

    return docFragment;
}

function GetRandomBetween(min, max) {
    var number = (min + Math.random() * (max - min)) | 0;
    return number;
}

function GetColor() {
    var red = ((Math.random() * 256) | 0) + ', ';
    var green = ((Math.random() * 256) | 0) + ', ';
    var blue = ((Math.random() * 256) | 0) + ')';
    return 'rgb(' + red + green + blue;
}

function GetCoord(height, width) {
    var coords =
        {
            left: (1 + Math.random() * 1750 - width) | 0,
            top: (1 + Math.random() * 910 - height) | 0
        };
    return coords;
}

function ConstructDiv(width, height, backgroundColor, fontColor, position, borderRadius, borderColor, borderWidth) {
    var div = document.createElement("div");
    div.style.position = 'absolute';
    div.style.width = width + 'px';
    div.style.backgroundColor = backgroundColor;
    div.style.color = fontColor;
    div.style.height = height + 'px';
    div.style.top = position.top + 'px';
    div.style.left = position.left + 'px';
    div.style.borderRadius = borderRadius + 'px';
    div.style.borderWidth = borderWidth + 'px';
    div.style.borderStyle = 'solid';
    div.style.borderColor = borderColor;
    return div;
  
}