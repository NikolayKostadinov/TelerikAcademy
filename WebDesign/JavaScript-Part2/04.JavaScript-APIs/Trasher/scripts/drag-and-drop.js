
function drag(ev) {
    ev.dataTransfer.setData('dragged-id', ev.target.id);
}

function allowDrop(ev) {
    ev.preventDefault();
    ev.target.style.backgroundImage = "url('images/trashcan-open.png')";
}

function drop(ev) {
    ev.preventDefault();
    var element = document.getElementById(ev.dataTransfer.getData('dragged-id'));
    element.parentElement.removeChild(element);
    ev.target.style.backgroundImage = "url('images/trashcan-close.png')";
}