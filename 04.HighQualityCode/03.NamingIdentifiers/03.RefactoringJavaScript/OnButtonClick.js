function onButtonClickEventHandler(event, arguments) {
    var currentWindow = window;
    var browserType = currentWindow.navigator.appCodeName;
    var isMozilla = (browserType == "Mozilla");

    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
