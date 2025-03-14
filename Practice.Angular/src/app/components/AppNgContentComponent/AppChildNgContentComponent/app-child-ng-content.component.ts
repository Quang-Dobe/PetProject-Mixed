import { Component, ViewEncapsulation } from "@angular/core";

@Component({
    selector: 'app-child-ng-content',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-child-ng-content.component.html',
    styleUrl: './app-child-ng-content.component.scss',
})
export default class AppChildNgContentComponent {
    
}