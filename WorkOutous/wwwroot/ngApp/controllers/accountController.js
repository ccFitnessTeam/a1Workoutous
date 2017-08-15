
class AccountController{
    constructor($account,$state) {
        this.userLogin = {
            username: "",
            password:""
        };
        this.userRegister = {
            username: "",
            password: "",
            firstname: "",
            lastname: "",
            email: "",
            isAdmin: false
        };
        this.passConfirm;
        this.account = $account;
        this.user;
        this.state = $state;
    }

    loginUser() {
        this.account.login(this.userLogin).then((res) => {
            this.user = res.data;
            
            sessionStorage.setItem("userToken", this.user.userId);
            sessionStorage.setItem("status", this.user.administrator);
            sessionStorage.setItem("loggedin", "loggedin");

        });
        
        this.state.go("home");
    }

    register() {
        if (this.userRegister.password != this.passConfirm)
        {
            alert("Comfirm Password invalid");
        }
        else {
            this.account.register(this.userRegister).then((res) => { this.user = res.data; });

        }
        this.loginUser();
        this.state.go("home");
    }

    logout() {
        sessionStorage.clear();
        this.state.go("home");
    }

    isLoggedin() {
        return sessionStorage.getItem("loggedin") == "loggedin";
    }
}