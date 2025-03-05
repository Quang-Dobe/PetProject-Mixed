export default class User {
    public id?: number;
    public name?: string;

    constructor(user?: User) {
        if (user == null) {
            return;
        }

        this.id = user.id;
        this.name = user.name;
    }
}