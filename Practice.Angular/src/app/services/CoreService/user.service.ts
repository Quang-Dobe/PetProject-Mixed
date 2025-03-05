import { Injectable } from "@angular/core";
import { delay, Observable, of } from "rxjs";
import User from "../../Domain/User";

@Injectable({
    providedIn: 'root'
})

export default class UserService {
    private defaultDelayTime = 2000;
    private allUsers: User[] = [
        { id: 1, name: 'Resource 1' },
        { id: 2, name: 'Resource 2' },
        { id: 3, name: 'Resource 3' }
    ];

    public getAllUsers(): Observable<User[]> {
        return of(this.allUsers).pipe(delay(this.defaultDelayTime));
    }
}