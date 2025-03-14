import { Component, effect, EventEmitter, Input, Output, signal, ViewEncapsulation, WritableSignal } from "@angular/core";
import RandomService from "../../../services/CommonService/random.service";

@Component({
    selector: 'app-child-data-binding',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-child-data-binding.component.html',
    styleUrl: './app-child-data-binding.component.scss',
})
export default class AppChildDataBindingComponent {
    private _oneWayData: string = '';
    private _twoWayData: string = '';
    private _oneWayDataRO: string = '';

    public set oneWayData(value: string) {
        this._oneWayData = value;
    };
    public set twoWayData(value: string) {
        this.twoWayDataChange.emit(value);
        this._twoWayData = value;
    };
    public set oneWayDataRO(value: string) {
        this.oneWayDataROChange.emit(value);
        this._oneWayDataRO = value;
    }

    @Input() public get oneWayData(): string {
        return this._oneWayData;
    };

    @Input() public get twoWayData(): string {
        return this._twoWayData;
    };

    @Input() public get oneWayDataRO(): string {
        return this._oneWayDataRO;
    };

    @Output() public twoWayDataChange: EventEmitter<string> = new EventEmitter<string>();

    @Output() public oneWayDataROChange: EventEmitter<string> = new EventEmitter<string>();

    public randomValue: WritableSignal<string> = signal('');

    constructor(private randomService: RandomService) {
        effect(() => this.twoWayData = `${this.randomValue()}`);
    }

    public onChangeSignalValue(): void {
        let randomValue = this.randomService.generateRandomString(3);
        // this.randomValue.update(_ => randomValue);

        // Test one way binding:
        let randomValueRO = randomValue === '' ? '000' : randomValue;
        this.oneWayDataRO = `Child - ${randomValueRO}`;
    }
}