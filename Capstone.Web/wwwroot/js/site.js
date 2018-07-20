// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}




function toggle-temp() {
    var buttonTxt = document.getElementById("convertBtn");
    if (buttonTxt.innerHTML == 'Convert To C') {
        buttonTxt.innerHTML = 'Convert To F';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToC(temps[i].textContent);
            console.log(temps[i]);
            
        }

    }
    else {
        buttonTxt.innerHTML = 'Convert To C';
        var temps = document.getElementsByClassName("temperature");
        for (var i = 0; i < temps.length; i++) {
            temps[i].textContent = convertToF(temps[i].textContent);
            console.log(temps[i]);
        }
    }
}



function convertToF(num) {
    var intNum = parseInt(num);
    console.log("this is convert to F");
    return intNum * 1.8 + 32;
};
function convertToC(num) {
    var intNum = parseInt(num);
    console.log("this is convert to C");
    return (intNum - 32) / 1.8;
};
