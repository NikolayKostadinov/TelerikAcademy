<<<<<<< HEAD
﻿//Create a text area and two inputs with type="color"
//Make the font color of the text area as the value of the first color input
//Make the background color of the text area as the value of the second input
(function () {
    'use strict';

})
=======
﻿(function () {
    'use strict';

    function addEventListener(selector, eventName, listener) {
        document.querySelector(selector).addEventListener(eventName, listener, false);
    }

    var textEl = document.querySelector('#text');

    addEventListener('#text-color', 'change', function (event) {
        textEl.style.color = event.target.value;
    });

    addEventListener('#text-background', 'change', function (event) {
        textEl.style.backgroundColor = event.target.value;
    });
})();
>>>>>>> 2d52fad01e6757c614d0642c536d46f459e5a767
