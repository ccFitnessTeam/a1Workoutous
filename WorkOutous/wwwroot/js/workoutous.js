// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("topBtn").style.display = "block";
    } else {
        document.getElementById("topBtn").style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0; // For Chrome, Safari and Opera 
    document.documentElement.scrollTop = 0; // For IE and Firefox
}

// Side nav-bar function
$(document).ready(function () {
    $(".button-collapse").sideNav();
});


//Input validation

//app.js
function HandleIT() {
    var name = document.getElementById('<%=txtname.ClientID %>').value;
    var address = document.getElementById('<%=txtaddress.ClientID %>').value;
    PageMethods.ProcessIT(usernameExists, passwordExists, onSucess, onError);
    function onSucess(result) {
        alert(result);
    }
    function onError(result) {
        alert('Something wrong.');
    }
}

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction();};

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("topBtn").style.display = "block";
    } else {
        document.getElementById("topBtn").style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0; // For Chrome, Safari and Opera 
    document.documentElement.scrollTop = 0; // For IE and Firefox
}

//carousel
$(document).ready(function () {
    $('.carousel').carousel();
});

