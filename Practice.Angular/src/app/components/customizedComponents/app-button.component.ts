import { 
    Component, 
    ViewEncapsulation, 
    WritableSignal,
    signal 
} from "@angular/core";
import RandomService from "../../services/CommonService/random.service";

@Component({
    selector: 'button[type="button"]',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    template: '<ng-content></ng-content>',
    styles: 'button { margin: 20px }',
    host: {
        '(click)': 'onAppButtonClick()'
    }
})

export default class AppButtonComponent {
    public signalValueDisplay: WritableSignal<string> = signal("App-button-component!")

    constructor(private randomService: RandomService) { }
    
    public onAppButtonClick(): void {
        this.signalValueDisplay.update(_ => this.randomService.generateRandomString(10));

        alert("Clicked app-button-component");
    }
}