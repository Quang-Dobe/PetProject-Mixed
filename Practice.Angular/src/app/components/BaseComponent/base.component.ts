import { 
    OnInit, 
    AfterContentInit, 
    AfterViewInit, 
    OnChanges, 
    OnDestroy, 
    SimpleChanges, 
    Component
} from "@angular/core";

@Component({
    template: ''
})

export class BaseComponent implements OnInit, AfterContentInit, AfterViewInit, OnChanges, OnDestroy {
    protected onInit(): void {
        // Do nothing...
    }

    protected onChanges(changes: SimpleChanges): void {
        // Do nothing...
    }

    protected afterContentInit(): void {
        // Do nothing...
    }

    protected afterViewInit(): void {
        // Do nothing...
    }

    protected onDestroy(): void {
        // Do nothing...
    }

    ngOnInit(): void {
        this.onInit();
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.onChanges(changes);
    }
    
    ngAfterContentInit(): void {
        this.afterContentInit();
    }

    ngAfterViewInit(): void {
        this.afterViewInit();
    }

    ngOnDestroy(): void {
        this.onDestroy();
    }
}