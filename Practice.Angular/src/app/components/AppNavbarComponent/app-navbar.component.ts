import { Component, ViewEncapsulation } from "@angular/core";
import { BaseComponent } from "../BaseComponent/base.component";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './app-navbar.component.html',
    styleUrl: './app-navbar.component.scss',
    encapsulation: ViewEncapsulation.None
})

export class AppNavbar extends BaseComponent {
    public navbarTitle: string = "Welcome!";
    public isActive: boolean = false;

    public onChangeColor(): void {
        this.isActive = !this.isActive;
    }
}