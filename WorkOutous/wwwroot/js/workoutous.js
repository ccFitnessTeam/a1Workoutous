//Input validation
function loginValidation(){
   var usernameExists = document.getElementById("Username").value;
   var passwordExists = document.getElementById("Pwd").value;
   var userErrorMessage = document.getElementById("userErrMsg");
   var pwdErrorMessage = document.getElementById("passErrMsg");

   userErrorMessage.innerHTML = '';
   pwdErrorMessage.innerHTML = '';
   
   if (usernameExists === "" ){
       userErrorMessage.innerHTML = 'Please enter a Username.';
   }

   if (passwordExists === "" ){
       pwdErrorMessage.innerHTML = 'Please enter a Password.';
   }
}

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