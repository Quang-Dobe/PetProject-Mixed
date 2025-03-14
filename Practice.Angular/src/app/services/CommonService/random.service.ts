import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export default class RandomService {
    public generateRandomString(length: number) {
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        let result = '';
        const charactersLength = characters.length;
        
        for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        
        return result;
    }
}