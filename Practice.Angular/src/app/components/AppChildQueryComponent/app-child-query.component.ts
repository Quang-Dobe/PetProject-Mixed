import { 
    Component, 
    ViewEncapsulation, 
    Signal, 
    effect, 
    viewChild,
    contentChild 
} from "@angular/core";
import { BaseComponent } from "../BaseComponent/base.component";
import AppChildQueryButtonComponent from "./AppChildQueryButtonComponent/app-child-query-button.component";
import AppButtonComponent from "../customizedComponents/app-button.component";
import { NgIf } from "@angular/common";

@Component({
    selector: 'app-child-query',
    standalone: true,
    encapsulation: ViewEncapsulation.None,
    imports: [AppChildQueryButtonComponent, NgIf],
    templateUrl: './app-child-query.component.html',
    styleUrl: './app-child-query.component.scss'
})
export default class AppChildQueryComponent extends BaseComponent {
    private viewChildButton: Signal<AppChildQueryButtonComponent | undefined> = viewChild(AppChildQueryButtonComponent);
    private contentChildButton: Signal<AppButtonComponent | undefined> = contentChild(AppButtonComponent);
    private _isVisible: boolean = true;

    public set isVisible(value: boolean) {
        this._isVisible = value;
    }

    public get isVisible(): boolean {
        return this._isVisible;
    }
    
    protected override onInit(): void {
        // this.onInitActions();
    }

    constructor() {
        super();

        // Just run once when this component is initialized
        effect(() => {
            if (this.viewChildButton()) {
                console.log("Updated view child button!");
            }

            if (this.contentChildButton()) {
                console.log("Updated content child button!");
            }
        })
    }

    public onChangeVisibility() {
        this.isVisible = !this.isVisible;
    }

    private onInitActions(): void {
        console.log("---OnInit---");
        console.log("Retrieving view child's value: ", this.viewChildButton()?.signalValueDisplay);
        console.log("Retrieving view child's value: ", this.contentChildButton()?.signalValueDisplay);
        console.log("-------------");
    }
}