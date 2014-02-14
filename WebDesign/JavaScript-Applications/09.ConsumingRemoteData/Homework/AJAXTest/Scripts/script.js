/// <reference path="http-request.js" />
/// <reference path="soapclient.js" />
/// <reference path="jquery-2.1.0.js" />
(function ($) {
    $(document).ready(function () {
        setInterval(function () {
            var now = new Date();
            var hh = now.getHours();
            var mm = now.getMonth();
            var ss = now.getSeconds();
            $('#clock').html(hh + ":" + mm + ":" + ss);
        }, 1000);

        //loadRssFeed("http://gong.bg/rss.php");
        //loadWeader("Burgas", 5);
        loadCacheData();

        setInterval(function () {
            loadRssFeed("http://gong.bg/rss.php");
        }, 600000);

        function parseJSON(records, target) {
            var table_obj = $('<table>');
            var trh = $('<tr>');
            trh.append($('<th>', { html: "№" }));
            for (var col in records[0]) {
                trh.append($('<th>', { html: col }));
            }
           
            //trh.append($('<th>', { html: "First Name" }));
            //trh.append($('<th>', { html: "Last Name" }));
            //trh.append($('<th>', { html: "Grade" }));

            table_obj.append(($('<thead>').append(trh)));

            $.each(records, function (index, item) {
                var table_row = $('<tr>', { id: index });
                var table_cell = $('<td>', { html: index + 1 });
                table_row.append(table_cell);
                $.each(item, function (index, prop) {
                    if (!(prop instanceof Function || prop instanceof Object))
                        table_cell = $('<td>', { html: prop });
                    table_row.append(table_cell);
                })
                table_obj.append(table_row);
            })
            $(target).append(table_obj);
        }

        function loadRssFeed(url, callback) {
            $.ajax({
                       url: document.location.protocol + '//ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=10&callback=?&q=' + encodeURIComponent(url),
                       dataType: 'json',
                       success: function (data) {
                           parseJSON(data.responseData.feed.entries, "#sport");
                       }
                   });
        }

        function loadWeader(place, days) {
            days = days || 2;
            place = place || "Burgas";
            var url = "http://api.worldweatheronline.com/free/v1/weather.ashx?q=" + place + "&format=json&num_of_days=" + days + "&key=cjpkbkcczugwa2bdrkwnp5qb";

            $.ajax({
                       type: 'GET',
                       url: url,
                       contentType: "application/json",
                       dataType: 'jsonp',
                       success: function (data) {
                           parseJSON(data.data.weather, "#weather");
                       },
                   });
        }

        function createCORSRequest(method, url) {
            var xhr = new XMLHttpRequest();
            if ("withCredentials" in xhr) {
                // XHR for Chrome/Firefox/Opera/Safari.
                xhr.open(method, url, true);
            } else if (typeof XDomainRequest != "undefined") {
                // XDomainRequest for IE.
                xhr = new XDomainRequest();
                xhr.open(method, url);
            } else {
                // CORS not supported.
                xhr = null;
            }
            return xhr;
        }

        function loadCacheData() {
            var url = "http://10.94.23.80:7777/DemoService.asmx";
                                    
            //var pl = new SOAPClientParameters();
            //SOAPClient.
            //SOAPClient.invoke(url, "HelloWorld", pl, true, function (data) {
            //    var data = data;
            //    alert("Fuck!!!");
            //})


            var xmlRequest = new XMLHttpRequest();
            xmlRequest.open("GET", url,true);
            xmlRequest.send(null);

            xmlRequest.onload = function()
            {
                console.log("readyState = " + xmlRequest.readyState + " | status = " + xmlRequest.status);
                if (xmlRequest.readyState == 4 && xmlRequest.status == 200)
                {
                    $("#cache-service").html(xmlRequest.responseText);
                    alert('fuck');
                }
            }
            //xmlRequest.onloadend = function () {
            //    console.log(xmlRequest.status);
            //    console.log(xmlRequest.responseXML);
            //}
            
           
            //xmlRequest.open("GET", url, true);
            //xmlRequest.send();
        }
    })
})(jQuery)