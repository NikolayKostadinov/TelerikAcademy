(function () {
    'use strict';
    var counter = 0;
    var immageConteiner = document.getElementById("immage-container");
    var immages = ["immages/1.jpg",
        "immages/2.jpg",
        "immages/3.jpg",
        "immages/4.jpg",
        "immages/5.jpg",
        "immages/6.jpg",
        "immages/7.jpg",
        "immages/8.jpg",
        "immages/9.jpg",
        "immages/10.jpg",
    ];
    var buttonPrev = document.getElementById('prev');
    var buttonNext = document.getElementById('next');

    immageConteiner.setAttribute("src", immages[counter]);
    buttonPrev.addEventListener('click', OnButtonClick, false);
    buttonNext.addEventListener('click', OnButtonClick, false);
    buttonPrev.addEventListener('mouseover', OnButtonHover, false);
    buttonNext.addEventListener('mouseover', OnButtonHover, false);
    buttonPrev.addEventListener('mouseout', OnButtonHover, false);
    buttonNext.addEventListener('mouseout', OnButtonHover, false);

    function OnButtonClick(ev) {
			ev.preventDefault();
        if (ev.target.id == 'next') {
            if (counter < (immages.length - 1)) {
                counter++;
            } else {
                counter = 0;
            }
            immageConteiner.setAttribute('src', immages[counter]);
        } else if (ev.target.id == 'prev') {
            if (counter > 0) {
                counter--;
            } else {
                counter = immages.length - 1;
            }
            immageConteiner.setAttribute('src', immages[counter]);
        }
    };

    function OnButtonHover(ev) {
        var span = document.querySelector(ev.target.tagName.toLowerCase()+ '#' + ev.target.id + ' span');
        if (span.style.visibility == 'hidden' || span.style.visibility == '') {
            span.style.visibility = 'visible';
        } else {
            span.style.visibility = 'hidden';
        }

    }

})();

