﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if (document.getElementsByClassName("detail-img").length > 0) {
    window.onload = showTemp();
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function switchCookie() {
    var unit = getCookie("Unit");
    if (unit == "F") {
        setCookie("Unit", "C", 2);
    } else if (unit == "C") {
        setCookie("Unit", "F", 2);
    } else if (unit == "") {
        setCookie("Unit", "C", 2);
    }

}

function showTemp() {
    var currentUnit = getCookie("Unit");
    var temps = document.getElementsByClassName("temperature");
    var btnTxt = document.getElementById("convertBtn");
    if (currentUnit == "C") {
        btnTxt.innerHTML = 'Convert To F';

        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToC(temps[i].textContent) + " °" + getCookie("Unit");
        }
    } else if (currentUnit == "" || currentUnit == "F") {
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent += " °F"
        }
    }
}

function toggleTemp() {
    var buttonTxt = document.getElementById("convertBtn");
    if (buttonTxt.innerHTML == 'Convert To C') {
        buttonTxt.innerHTML = 'Convert To F';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToC(temps[i].textContent) + " °" + getCookie("Unit");
        }
    }
    else {
        buttonTxt.innerHTML = 'Convert To C';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToF(temps[i].textContent) + " °" + getCookie("Unit");
        }
    }
    switchCookie();
}



function convertToF(num) {
    var intNum = parseInt(num);
    return (intNum * (9.0 / 5.0) + 32).toPrecision(2);
};
function convertToC(num) {
    var intNum = parseInt(num);
    return ((intNum - 32) * 5 / 9).toPrecision(2);
};


/* JS FOR STYLING HOME */

//var parklisting = document.getElementsByClassName("park-listing");

//parklisting

$(".park-link").hover(function () {
    var info = $(this).find(".state-description");
    info.css({ "display": "block", "color": "cornsilk", "font-size": "1.5rem", "background-color": "rgba(10, 10, 10, 0.575)" });
},
    function () {
        var info = $(".state-description");
        info.css("display", "none");
    }
);

