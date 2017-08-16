class ProfileController {
    constructor($account) {
        this.account = $account;
        this.userId = sessionStorage.getItem("userToken");
        this.getWorkouts(this.userId);
        this.workouts;
        this.user;
        this.getUserInfo();
    }

    getUserInfo() {
        var id = sessionStorage.getItem("userToken");
        this.account.getUser(id).then((res) => {
            this.user = res.data;
        });
    }

    getWorkouts(uid) {
        this.account.getWorkOutsById(uid).then((res) => {
            this.workouts = res.data
        });
    }
}