import { Component, signal, ViewEncapsulation, WritableSignal } from "@angular/core";
import RandomService from "../../../services/CommonService/random.service";

@Component({
    selector: 'button[type="submit"]',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    template: '<ng-content></ng-content>',
    styles: 'button { margin: 20px }',
    host: {
        '(click)': 'onAppButtonClick()'
    }
})

export default class AppChildQueryButtonComponent {
    public signalValue: WritableSignal<string> = signal("App-child-query-button-component!");

    public get signalValueDisplay(): string {
        return this.signalValue();
    }

    constructor(private randomService: RandomService) { }
    
    public onAppButtonClick(): void {
        this.signalValue.update(_ => this.randomService.generateRandomString(10));

        alert("Clicked app-button-component");
    }
}