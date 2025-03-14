import { Component, ViewEncapsulation } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppNavbar } from '../AppNavbarComponent/app-navbar.component';
import AppSignals from '../AppSignalsComponent/app-signals.component';
import AppResource from '../AppResourceComponent/app-resource.component';
import AppCustomizedButton from '../AppCustomizedButtonComponent/app-customized-button.component';
import AppDataBindingComponent from '../AppDataBindingComponent/app-data-binding.component';
import AppNgContent from "../AppNgContentComponent/app-ng-content.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppNavbar, AppSignals, AppCustomizedButton, AppResource, AppDataBindingComponent, AppNgContent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  public title: string = 'Noah';
}
