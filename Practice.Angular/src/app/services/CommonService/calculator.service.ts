import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})
export default class CalculatorService {
    public Sum(...args: number[]): number {
        return args.reduce((prev, cur, idx, arr) => prev + cur, 0);
    }
}