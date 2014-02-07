/// <reference path="q.js" />

var api = (function ($) {

    var locationElement = {};

    function setLocationElement(selector) {
        locationElement = $(selector).first();
    }

    function displayTime(selector) {
        var currentTime = new Date();
        var h = currentTime.getHours();
        var m = currentTime.getMinutes();
        var s = currentTime.getSeconds();
        var time = h + ":" + m + ":" + s;
        $(selector).first().html(time);
    }

    function getGeolocationPromice(){
        var deferred = Q.defer();

        navigator.geolocation.getCurrentPosition(
            function (position) {
                deferred.resolve(position)
            },
            function (err) {
                deferred.reject(err);
            });
        return deferred.promise;
    }

    function parseLatAndLongCoords(geolocationPosition) {
        if (geolocationPosition.coords) {
            return { lat: geolocationPosition.coords.latitude, long: geolocationPosition.coords.longitude };
        }
        else {
            throw { message: "No coords element found", name: "UserException" };
        }
    }

    function createGeolocationImage(coordsObj) {
        var imgElement = $(document.createElement("img"));
        var label = "M";
        var imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" + coordsObj.lat + "," + coordsObj.long + "&markers=color:blue%7Clabel:"+label+"%7C" + coordsObj.lat + "," + coordsObj.long + "&zoom=13&size=500x500" + "&sensor=true"
        

        imgElement.prop("src", imgSrc);
        locationElement.append(imgElement);
        //imgElement.fadeOut(0);
        //imgElement.fadeIn(5000);
    }

    function viewError(err) {
        alert(err.message);
    }

    function getGeoLocation(){
        getGeolocationPromice().
            then(parseLatAndLongCoords).
            then(createGeolocationImage, viewError).
            done();
    }

    return {
        displayTime: displayTime,
        setLocationElement: setLocationElement,
        getGeoLocation: getGeoLocation
    }

    
})(jQuery);

setInterval(function () { api.displayTime('#clock'); }
        ,1000);

api.setLocationElement('#locator');
api.getGeoLocation();