var gameEngine = (function () {

    var highScore = [];
    var startTime;
    var currentPlayer = new (function (name, time) {
        this.name = name;
        this.time = time;
    })();

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

        if (checkEndOfTheGame()) {
            getPlayerResult();
            gerPlayerName();
            getHighScore();
            QualifyCurrentPlayer();
            renderHighScore();
        }
    }

    function checkEndOfTheGame() {
        var trashCount = document.getElementsByClassName('trash');
        if (trashCount.length > 0) {
            return false;
        }
        return true;
    }

    function gerPlayerName() {
        var name = prompt("name", "Enter you nickname");
        currentPlayer.name = name;
    }

    function getPlayerResult() {
        currentPlayer.time = Date.now() - startTime;
    }

    function getHighScore() {
        var scores = localStorage.getObject('highScore');
        if (scores) {
            highScore = localStorage.getObject('highScore');
        } else {
            highScore = new Array();
        }
    }

    function setHightScore() {
        if (highScore.length > 0) {
            localStorage.setObject('highScore', setHightScore);
        }
    }

    function QualifyCurrentPlayer() {
        if (highScore.length == 0) {
            highScore.push(currentPlayer);
        } else {
            highScore.push(currentPlayer);
            highScore.sort(function (x, y) {
                if (x.time > y.time) {
                    return 1;
                } else if (x.time == y.time) {
                    return 0;
                } else {
                    return -1;
                }
            });

            var maxRecordInList = 5;
            if (highScore.length > maxRecordInList) {

                highScore = highScore.slice(0, maxRecordInList);
            }
        }

        localStorage.setObject('highScore', highScore);
    }

    function renderHighScore() {
        var lineText = "";
        var fragment = document.createDocumentFragment();
        for (var i = 0; i < highScore.length; i++) {
            lineText = "" + (i + 1) + ". " + highScore[i].name + ' - ' + highScore[i].time;
            var p = document.createElement('p');
            p.innerHTML = lineText;
            fragment.appendChild(p);
        }
        var divHightScore = document.getElementById("hightscores");
        var nodes = divHightScore.childNodes;
        if (nodes.length > 1) {
            for (var i = nodes.length; i > 1; i--) {
                if (nodes[i]) {
                    divHightScore.removeChild(nodes[i]);
                }
            }
        }
        divHightScore.appendChild(fragment);
    }

    function startGame() {
        getHighScore();
        renderHighScore();
        startTime = Date.now();
    }

    return {
        startGame: startGame,
        drag: drag,
        allowDrop: allowDrop,
        drop: drop,
    }
})();

