id = 1
function deepCopy(inObj) {
    var cloneObj = new Object;
    
    for (var i in inObj) {
        if (typeof inObj[i] === "object") {
            id += 1;
            cloneObj[i] = deepCopy(inObj[i]);
            id -= 1;
        }
        else {
            cloneObj[i] = inObj[i];
        }
    }
    jsConsole.writeLine(id);
    return cloneObj;
}