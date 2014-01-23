(function(){
    function GetCoord(height, width) {
        var coords =
            {
                left: (1 + Math.random() * 1750 - width) | 0,
                top: (1 + Math.random() * 910 - height) | 0
            };
        return coords;
    }

    (function GenerateTwentyTrashes() {
        var trashDiv = document.getElementById('trash0');
        var fragment = document.createDocumentFragment();
        for (var i = 1; i < 20; i++) {
            var coords = GetCoord(trashDiv.style.height, trashDiv.style.width);
            trashDiv.style.position = 'absolute';
            trashDiv.style.top = coords.top + 'px';
            trashDiv.style.left = coords.left + 'px';
            trashDiv.id = 'trash' + i;
            fragment.appendChild(trashDiv.cloneNode(true));
        }
        document.body.appendChild(fragment);
    })();
})();