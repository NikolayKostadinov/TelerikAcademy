/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="jquery-2.0.2.js" /> 

var persisters = (function () {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    function saveUserData(data) {
        localStorage.setItem("nickname", data.nickname);
        localStorage.setItem("sessionKey", data.sessionKey);
        nickname = data.nickname;
        sessionKey = data.sessionKey;
    }

    var MainPersister = Class.create({
        init: function (mainUrl) {
            this.mainUrl = mainUrl;
            this.user = new UserPersister(mainUrl);
            this.game = new GamePersister(mainUrl);
            this.guess = new GuessPersister(mainUrl);
            this.message = new MessagesPersister(mainUrl);
        },

        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },
        nickname: function () {
            return nickname;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "user/";
        },

        login: function (user, success, error) {

            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData,
				function (data) {
				    saveUserData(data);
				    success(data);
				}, error);
        },
        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData,
				function (data) {
				    saveUserData(data);
				    success(data);
				}, error);
        },
        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;

            httpRequester.getJSON(url,
				function (data) {
				    clearUserData();
				    success(data);
				}, error);
        },
        scores: function (success, error) {
            var url = this.rootUrl + "scores/" + sessionKey;

            httpRequester.getJSON(url,
				function (data) {
				    success(data);
				}, error);
        }

    });

    var GamePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "game/";
        },
        //game = {
        //  gameId
        //  password
        //  number
        //}
        create: function (game, success, error) {
            var url = this.rootUrl + "create/" + sessionKey;
            gameData = {
                dameId: game.gameId,
                number: number
            }

            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }

            httpRequester.postJSON(url, gameData, success, error);
        },
        start: function (gameId, success, error) {
            var url = this.rootUrl + "start/" + sessionKey;
            httpRequester.postJSON(url, gameId, success, error);
        },
        join: function (game, success, error) {
            var gameData = {
                gameId: game.gameId,
                number: game.number
            };
            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }
            var url = this.rootUrl + "join/" + sessionKey;
            httpRequester.postJSON(url, gameData, success, error);
        },
        open: function (success, error) {
            var url = this.rootUrl + "open/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },
        myActive: function (success, error) {
            var url = this.rootUrl + "my-active/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },
        state: function (gameId, success, error) {
            var url = this.rootUrl + gameId + "/state/" + sessionKey;
            httpRequester.getJSON(url, success, error)
        }
    });

    var GuessPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "guess/";
        },
        make: function (guess, success, error) {
            var url = this.rootUrl + "make/" + sessionKey;
            httpRequester.postJSON(url, guess, success, error);
        }
    });

    var MessagesPersister = Class.create({
        init: function (url) {
            this.rootUrl = url + "messages/";
        },
        unread: function (success, error) {
            var url = this.rootUrl + "unread/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },
        all: function (success, error) {
            var url = this.rootUrl + "all/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        }
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
})();
