(function () {
    'use strict';

    var count = 12;
    var radius = 50;
    var divs = Array(count);
    var angles = Array(count);

    //function GenerateDivs() {
        var div = document.createElement("div");
        div.style.position = 'absolute';
        div.style.height = '20px';
        div.style.width = '20px';
        div.style.border = '2px solid #0094ff';
        div.style.backgroundColor = '#0ff'
        div.style.borderRadius = '20px';

        for (var i = 0; i < divs.length; i++) {

            divs[i] = CalculatePosition(0, 360 / count, div.cloneNode(true), radius);
            angles[i] = i * 360 / count;
        }

        for (var i = 0; i < divs.length; i++) {
            document.body.appendChild(divs[i]);
        }

        timer = setInterval(function () {
            var step = -5;
            for (var i = 0, len = divs.length; i < len; i++) {
                div[i] = CalculatePosition(angles[i], step, divs[i], radius);
                angles[i] += step;
                if (angles[i] > 360) {
                    angles[i] -= 360;
                }
            }
        }, 100);

    //}

    function CalculatePosition(oldAngle, newAngle, div, radius) {
        var x = 850;
        var y = 400;

        var angle = oldAngle + newAngle;
        if (angle > 360) { angle -= 360; }
        var cx = x - radius * Math.cos(angle * Math.PI / 180);
        var cy = y + radius * Math.sin(angle * Math.PI / 180);
        div.style.top = cy + 'px';
        div.style.left = cx + 'px';

        return div;
    }
})();