import { 
    Component, 
    EventEmitter, 
    Input, 
    Output, 
    ViewEncapsulation, 
    WritableSignal, 
    effect,
    signal, 
} from "@angular/core";
import { BaseComponent } from "../BaseComponent/base.component";
import UserService from "../../services/CoreService/user.service";
import AppButtonComponent from "../customizedComponents/app-button.component";

@Component({
    selector: 'app-resource',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-resource.component.html',
    styleUrl: './app-resource.component.scss'
})

export default class AppResource extends BaseComponent {
    private userId: WritableSignal<number> = signal(-1);
    private _oneWayData: string = '';
    private _twoWayData: string = '';

    public set oneWayData(value: string) {
        this._oneWayData = value;
    };
    public set twoWayData(value: string) {
        this.twoWayDataChange.emit(value);
        this._twoWayData = value;
    };

    @Input() public get oneWayData(): string {
        return this._oneWayData;
    };

    @Input() public get twoWayData(): string {
        return this._twoWayData;
    };

    @Output() public twoWayDataChange: EventEmitter<string> = new EventEmitter<string>(); 

    public get getUserId(): number {
        return this.userId();
    }

    constructor(
        private userService: UserService
    ) {
        super();

        effect(() => {
            console.log(`Testing on signalValue: ${this.userId()}`);

            // Wait until userId is updated, then set new data 
            // -> Trigger setter of parent component 
            // -> Trigger signal-update function 
            // -> Trigger effect logic inside parent component
            this.twoWayData = `${this.userId() + 1}`;
        });
    }

    public onChangeSignalValue(): void {
        this.userService.getAllUsers().subscribe(_ => this.userId.update(cur => ++cur));
    }
}