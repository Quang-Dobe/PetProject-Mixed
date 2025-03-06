import { Component, ViewEncapsulation } from "@angular/core";

@Component({
    selector: 'button[type="button"]',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    template: '<ng-content></ng-content>',
    host: {
        '(click)': 'onAppButtonClick()'
    }
})

export default class AppButtonComponent {
    public onAppButtonClick(): void {
        alert("Clicked app-button-component");
    }
}