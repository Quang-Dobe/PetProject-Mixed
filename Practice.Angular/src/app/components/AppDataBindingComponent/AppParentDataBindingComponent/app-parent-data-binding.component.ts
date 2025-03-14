import { Component, effect, signal, ViewEncapsulation, WritableSignal } from "@angular/core";
import AppChildDataBindingComponent from "../AppChildDataBindingComponent/app-child-data-binding.component";
import RandomService from "../../../services/CommonService/random.service";

@Component({
    selector: 'app-parent-data-binding',
    standalone: true,
    imports: [AppChildDataBindingComponent],
    templateUrl: './app-parent-data-binding.component.html',
    styleUrl: './app-parent-data-binding.component.scss',
    encapsulation: ViewEncapsulation.None
})
export default class AppParentDataBindingComponent {
    private _oneWayDataBindingValue: string = 'Welcome!';
    private _twoWayDataBindingValue: string = 'Hello';
    private _oneWayDataROBindingValue: string = 'Parent - 000';

    public oneWayDataSignal: WritableSignal<string> = signal(this.oneWayDataBindingValue);
    public twoWayDataSignal: WritableSignal<string> = signal(this.twoWayDataBindingValue);
    public oneWayDataROSignal: WritableSignal<string> = signal(this.oneWayDataROBindingValue);

    public set oneWayDataBindingValue(value: string) {
        this._oneWayDataBindingValue = value;
        this.oneWayDataSignal.update(_ => this._oneWayDataBindingValue);
    }
    public set twoWayDataBindingValue(value: string) {
        this._twoWayDataBindingValue = value;

        // This is reason why we need to have getter/setter func (To trigger update -> Trigger effect logic)
        this.twoWayDataSignal.update(_ => this._twoWayDataBindingValue);
    }
    public set oneWayDataROBindingValue(value: string) {
        this._oneWayDataROBindingValue = value;

        this.oneWayDataROSignal.update(_ => this._oneWayDataROBindingValue);
    }

    public get oneWayDataBindingValue(): string {
        return this._oneWayDataBindingValue;
    };
    public get twoWayDataBindingValue(): string {
        return this._twoWayDataBindingValue;
    };
    public get oneWayDataROBindingValue(): string {
        return this._oneWayDataROBindingValue;
    };

    constructor(private randomService: RandomService) {
        // Instead of doing some fuking thing like this by tracking signals
        // We can define a computed variable get() and show that on UI in real-time (two-way binding)
        effect(() => console.log(`Tracking these value: ${this.oneWayDataSignal()}, ${this.twoWayDataSignal()}, ${this.oneWayDataROSignal()}`))
    }

    public onChangeOneWayDataROBindingValue(): void {
        this.oneWayDataROBindingValue = `Parent - ${this.randomService.generateRandomString(3)}`;
    }

    public onChangeChildOneWayDataROBindingValue(value: any) {
        this.oneWayDataROBindingValue = value;
    }
}