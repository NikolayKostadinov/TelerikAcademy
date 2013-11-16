function makePoint(X, Y) {
    if (typeof X === "number" && typeof Y === "number") {
        return {
            X: X,
            Y: Y,
        }
    } else {
        alert("The coords of the point must be number!");
    }
}

function makeLine(point1, point2) {
    if ((point1.X != undefined) && (point1.Y != undefined) &&
        (point2.X != undefined) && (point2.Y != undefined)) {
        return {
            point1: point1,
            point2: point2,
            lineLenght: function () {
                return Math.sqrt(((point1.X - point2.X) * (point1.X - point2.X)) +
                    ((point1.Y - point2.Y) * (point1.Y - point2.Y)));
            }
        }


    } else {
        alert("The members of line must me valid points!");
    }
}