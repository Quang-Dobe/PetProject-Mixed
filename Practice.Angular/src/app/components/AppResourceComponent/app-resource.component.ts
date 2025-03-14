import { 
    Component, 
    ViewEncapsulation, 
    WritableSignal, 
    effect,
    signal, 
} from "@angular/core";
import { BaseComponent } from "../BaseComponent/base.component";
import UserService from "../../services/CoreService/user.service";

@Component({
    selector: 'app-resource',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-resource.component.html',
    styleUrl: './app-resource.component.scss'
})

export default class AppResource extends BaseComponent {
    private userId: WritableSignal<number> = signal(-1);
    
    public get getUserId(): number {
        return this.userId();
    }

    constructor(private userService: UserService) {
        super();

        effect(() => {
            console.log(`Testing on signalValue: ${this.userId()}`);
        });
    }

    public onChangeSignalValue() {
        this.userService.getAllUsers().subscribe(_ => this.userId.update(cur => ++cur));
    }
}