import { Component, ViewEncapsulation } from "@angular/core";
import AppButtonComponent from "../customizedComponents/app-button.component";

@Component({
    selector: 'app-customized-button',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    imports: [AppButtonComponent],
    styleUrl: './app-customized-button.component.scss',
    templateUrl: './app-customized-button.component.html'
})
export default class AppCustomizedButton {
    
}