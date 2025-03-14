import { Component, ViewEncapsulation } from "@angular/core";
import AppParentNgContentComponent from "./AppParentNgContentComponent/app-parent-ng-content.component";
import AppChildNgContentComponent from "./AppChildNgContentComponent/app-child-ng-content.component";

@Component({
    selector: 'app-ng-content',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    imports: [AppParentNgContentComponent, AppChildNgContentComponent, AppChildNgContentComponent],
    templateUrl: './app-ng-content.component.html',
    styleUrl: './app-ng-content.component.scss'
})
export default class AppNgContent {

}