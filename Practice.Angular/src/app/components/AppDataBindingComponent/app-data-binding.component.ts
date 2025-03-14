import { Component, ViewEncapsulation } from "@angular/core";
import AppParentDataBindingComponent from "./AppParentDataBindingComponent/app-parent-data-binding.component";

@Component({
    selector: 'app-data-binding',
    standalone: true,
    imports: [AppParentDataBindingComponent],
    encapsulation: ViewEncapsulation.None,
    templateUrl: './app-data-binding.component.html',
    styleUrl: './app-data-binding.component.scss'
})
export default class AppDataBindingComponent {
    
}