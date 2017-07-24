class LogInController {
    constructor($mainService) {
        this.message = 'login page';
        this.mainService = $mainService;
        this.userLoginResource = "/api/user/";
        this.user;
        this.IsLoggedIn;
        this.IsAdmin;
    }

     loginValidation() {
         var usernameExists = document.getElementById("Username").value;
         var passwordExists = document.getElementById("Pwd").value;
         var userErrorMessage = document.getElementById("userErrMsg");
         var pwdErrorMessage = document.getElementById("passErrMsg");
         var nameEntered = false;
         var passwordEntered = false;
         var stuff;

         userErrorMessage.innerHTML = '';
         pwdErrorMessage.innerHTML = '';

         if (usernameExists === "") {
             userErrorMessage.innerHTML = 'Please enter a Username.';
         } else {
             nameEntered = true;
         }

         if (passwordExists === "") {
             pwdErrorMessage.innerHTML = 'Please enter a Password.';
         } else {
             passwordEntered = true;
         }
         if (nameEntered && passwordEntered) {
             this.mainService.checkUser(usernameExists, passwordExists);
         }
         return;
     }
}