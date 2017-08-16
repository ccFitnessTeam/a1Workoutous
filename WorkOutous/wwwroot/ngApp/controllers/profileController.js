class ProfileController {
    constructor($account) {
        this.account = $account;
        this.userId = sessionStorage.getItem("userToken");
        this.getWorkouts(this.userId);
    }

    getWorkouts(uid) {
        this.account.getWorkOutsById(uid).then((res) => { this.workouts = res.data });
    }
}