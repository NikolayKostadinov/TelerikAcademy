
var movingShapes = (function () {
    'use strict';
    var div_height = 50;
    var div_width = 100;
    var circularPosition = [];
    var rectPosition = [];
    var divs = [];
    var timer = null;

    function add(trajectory) {
        stopMove();
        if (!divs[trajectory]) {
            divs[trajectory] = document.createDocumentFragment();
        }
        var div = GenerateRandomDiv(trajectory);
        divs[trajectory].appendChild(div);

        if (trajectory == 'circular') {
            circularPosition.push({
                angle: GetRandomBetween(0, 360),
                center: {
                    x: GetRandomBetween(div_width, 1800),
                    y: GetRandomBetween(div_height, 800)
                }
            });
        }

        if (trajectory == 'rect') {
            rectPosition.push({
                originalX: parseInt(div.style.left),
                originalY: parseInt(div.style.top),
                currentX: parseInt(div.style.left),
                currentY: parseInt(div.style.top),
                nextStep: 'up',
                sideLen: GetRandomBetween(200, 500),

            });
        }
    }

    function ShowDivs() {
        for (var trajectory in divs) {
            document.body.appendChild(divs[trajectory]);
        }

        StartMove();
    }

    function GenerateRandomDiv(className) {
        var div_max_top = 800 - div_height;
        var div_max_left = 1800 - div_width;
        var div = document.createElement("div");
        div.style.position = 'absolute';
        div.style.height = div_height + 'px';
        div.style.width = div_width + 'px';
        div.style.backgroundColor = GetColor();
        div.style.color = GetColor();
        div.style.border = '2px solid ' + GetColor();
        div.style.top = GetRandomBetween(div_height / 2, div_max_top) + 'px';
        div.style.left = GetRandomBetween(div_width / 2, div_max_left) + 'px';
        div.className = className;
        return div;
    }

    function GetColor() {
        var red = ((Math.random() * 256) | 0) + ', ';
        var green = ((Math.random() * 256) | 0) + ', ';
        var blue = ((Math.random() * 256) | 0) + ')';
        return 'rgb(' + red + green + blue;
    }

    function GetRandomBetween(min, max) {
        var number = (min + Math.random() * (max - min)) | 0;
        return number;
    }

    function CalculateNextCircPosition(oldAngle, step, div, center) {
        var radius = 200;
        var angle = oldAngle + step;
        if (angle > 360) { angle -= 360; }
        var cx = center.x - radius * Math.cos(angle * Math.PI / 180);
        var cy = center.y + radius * Math.sin(angle * Math.PI / 180);
        div.style.top = cy + 'px';
        div.style.left = cx + 'px';
        return div;
    }

    function CalculateNextRectPosition(rectPosition, step, currentDiv) {
        var rectSide = rectPosition.sideLen;
        //going UP
        if ((rectPosition.nextStep == 'up') && ((rectPosition.currentY - rectPosition.originalY) < rectSide)) {
            rectPosition.currentY -= step;
            if ((rectPosition.originalY - rectPosition.currentY) >= rectSide) {
                rectPosition.currentY = rectPosition.originalY - rectSide;
                rectPosition.nextStep = 'right';
            }
            currentDiv.style.top = rectPosition.currentY + 'px';
            return currentDiv;
        }

        //going Right
        if ((rectPosition.nextStep == 'right') && ((rectPosition.currentX - rectPosition.originalX) < rectSide)) {
            rectPosition.currentX += step;
            if ((rectPosition.currentX - rectPosition.originalX) >= rectSide) {
                rectPosition.currentX = rectPosition.originalX + rectSide;
                rectPosition.nextStep = 'down';
            }
            currentDiv.style.left = rectPosition.currentX + 'px';
            return currentDiv;
        }

        //going DOWN
        if ((rectPosition.nextStep == 'down') && (rectPosition.originalY > rectPosition.currentY)) {
            rectPosition.currentY += step;
            if ((rectPosition.originalY - rectPosition.currentY) <= 0) {
                rectPosition.currentY = rectPosition.originalY;
                rectPosition.nextStep = 'left';
            }
            currentDiv.style.top = rectPosition.currentY + 'px';
            return currentDiv;
        }

        //going Left
        if ((rectPosition.nextStep == 'left') && ((rectPosition.currentX - rectPosition.originalX) > 0)) {
            rectPosition.currentX -= step;
            if ((rectPosition.currentX - rectPosition.originalX) <= 0) {
                rectPosition.currentX = rectPosition.originalX;
                rectPosition.nextStep = 'up';
            }
            currentDiv.style.left = rectPosition.currentX + 'px';
            return currentDiv;
        }
    }

    function MoveDivs() {
        var step = 5;
        var nodesCirc = document.getElementsByClassName('circular');
        var nodesRect = document.getElementsByClassName('rect');

        for (var i = 0, lenCirk = nodesCirc.length; i < lenCirk; i++) {
            var currentDiv = nodesCirc[i];
            currentDiv = CalculateNextCircPosition(circularPosition[i].angle, step, currentDiv, circularPosition[i].center);
            circularPosition[i].angle += step;
            if (circularPosition[i].angle > 360) {
                circularPosition[i].angle -= 360;
            }
        }

        for (var j = 0, lenRect = nodesRect.length; j < lenRect; j++) {
            var currentDiv = nodesRect[j];
            currentDiv = CalculateNextRectPosition(rectPosition[j], step, currentDiv);
        }
    }

    function StartMove() {
        timer = setInterval(MoveDivs, 50);
    }

    function stopMove() {
        clearInterval(timer);
    }

    return {
        add: add,
        ShowDivs: ShowDivs,
        Stop: stopMove,
    }
})();

movingShapes.ShowDivs();

var buttonCirc = document.createElement('button');
buttonCirc.innerHTML = 'Get Circular';
buttonCirc.addEventListener('click', function () { movingShapes.add('circular'); movingShapes.ShowDivs(); });
var buttonRect = document.createElement('button');
buttonRect.innerHTML = 'Get Rectangular';
buttonRect.addEventListener('click', function () { movingShapes.add('rect'); movingShapes.ShowDivs(); });

document.body.appendChild(buttonCirc);
document.body.appendChild(buttonRect);
