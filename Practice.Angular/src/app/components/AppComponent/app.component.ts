import { Component, effect, signal, ViewEncapsulation, WritableSignal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppNavbar } from '../AppNavbarComponent/app-navbar.component';
import AppSignals from '../AppSignalsComponent/app-signals.component';
import AppResource from '../AppResourceComponent/app-resource.component';
import AppCustomizedButton from '../AppCustomizedButtonComponents/app-customized-button.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppNavbar, AppSignals, AppResource, AppCustomizedButton],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  private _oneWayDataBindingValue: string = 'Welcome!';
  private _twoWayDataBindingValue: string = 'Hello';

  public title: string = 'Noah';
  public oneWayDataSignal: WritableSignal<string> = signal(this.oneWayDataBindingValue);
  public twoWayDataSignal: WritableSignal<string> = signal(this.twoWayDataBindingValue);

  public set oneWayDataBindingValue(value: string) {
    this._oneWayDataBindingValue = value;
    this.oneWayDataSignal.update(_ => this._oneWayDataBindingValue);
  }
  public set twoWayDataBindingValue(value: string) {
    this._twoWayDataBindingValue = value;

    // This is reason why we need to have getter/setter func (To trigger update -> Trigger effect logic)
    this.twoWayDataSignal.update(_ => this._twoWayDataBindingValue);
  }

  public get oneWayDataBindingValue(): string {
    return this._oneWayDataBindingValue;
  };
  public get twoWayDataBindingValue(): string {
    return this._twoWayDataBindingValue;
  };

  constructor() {
    // Instead of doing some fuking thing like this by tracking signals
    // We can define a computed variable get() and show that on UI in real-time (two-way binding)
    effect(() => console.log(`Tracking these value: ${this.oneWayDataSignal()}, ${this.twoWayDataSignal()}`))
  }
}
