
class AccountController{
    constructor($account) {
        this.userLogin = {
            username: "",
            password:""
        };
        this.userRegister = {
            username: "",
            password: "",
            firstname: "",
            lastname: "",
            email:  ""
        };
        this.passConfirm;
        this.account = $account;
        this.user;
    }

    loginUser() {
        this.account.login(this.userLogin).then((res) => { this.user = res.data; });
    }

    register() {
        if (this.userRegister.password != this.passConfirm)
        {
            alert("Comfirm Password invalid");
        }
        else
        this.account.register(this.userRegister).then((res) => { this.user = res.data; });
    }
}