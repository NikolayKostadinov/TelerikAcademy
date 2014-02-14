/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="jquery-2.0.2.js" /> 

var persisters = (function () {
    var MainPersister = Class.create({
        init: function (mainUrl) {
            this.mainUrl = mainUrl;
            this.user = new UserPersister(mainUrl);
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
				    //saveUserData(data);
				    success(data);
				}, error);
        },

        register: function () { },
        logout: function () { },
        scores: function () { }

    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
})();

$(document).ready(function () {
    var url = "http://localhost:40643/api/";
    var persister = persisters.get(url);

    user = {
        username: "Manhattan",
        password: "12345678"
    };

    persister.user.login(user, function (data) {
        alert(data.nickname + " " + data.sessionKey);
    }, function (err) {
        alert(err.statusText);
    });
})