import { 
    Component, 
    Signal, 
    ViewEncapsulation, 
    WritableSignal, 
    computed, 
    effect, 
    signal
} from "@angular/core";
import { BaseComponent } from "../BaseComponent/base.component";
import CalculatorService from "../../services/CommonService/calculator.service";

@Component({
    selector: 'app-signals',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-signals.component.html',
    styleUrl: './app-signals.component.scss'
})

export default class AppSignals extends BaseComponent {
    private signalCounter: number = 0;
    private defaultSignalValue: string = 'Default value';
    private signalValue: WritableSignal<string> = signal(this.defaultSignalValue, { equal: this.compareObjectFunc });
    private computedSignalValue: Signal<number> = computed(() => this.signalValue() === this.defaultSignalValue ? 0 : ++this.signalCounter);

    public get signalDisplayValue(): string {
        return this.signalValue();
    }

    public get descriptionDisplayValue(): string {
        let total = this.calculatorService.Sum(this.signalCounter, 100);

        return `Render ${total} time(s)`;
    }

    constructor(
        private calculatorService: CalculatorService
    ) {
        super();

        effect(() => {
            console.log(`Testing on signalValue: ${this.signalValue()}`);
        });
    }

    public onChangeSignalValue(): void {
        this.signalValue.set(`${this.defaultSignalValue} ${this.computedSignalValue()}`)
    }

    private compareObjectFunc(prev: any, next: any): boolean {
        return JSON.stringify(prev) === JSON.stringify(next);
    }
}