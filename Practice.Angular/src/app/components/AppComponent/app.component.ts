import { Component, ViewEncapsulation } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppNavbar } from '../AppNavbarComponent/app-navbar.component';
import AppSignals from '../AppSignalsComponent/app-signals.component';
import AppResource from '../AppResourceComponent/app-resource.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppNavbar, AppSignals, AppResource],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  public title: string = 'Noah';
}
