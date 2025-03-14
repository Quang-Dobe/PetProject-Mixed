import { Component, ViewEncapsulation } from "@angular/core";

@Component({
    selector: 'app-parent-ng-content',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-parent-ng-content.component.html',
    styleUrl: './app-parent-ng-content.component.scss',
})
export default class AppParentNgContentComponent {

}