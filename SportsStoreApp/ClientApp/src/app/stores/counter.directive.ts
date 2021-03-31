import { Directive, Input, ViewContainerRef, TemplateRef, SimpleChange } from '@angular/core';

@Directive({
  selector: '[counterOf]'
})

export class CounterDirective {
  constructor(private container: ViewContainerRef, private template: TemplateRef<object>) {
    this.counter = 0;
  }

  @Input('counterOf') counter: number;

  ngOnChanges(changes: SimpleChange) {
    this.container.clear();
    for (var i = 0; i < this.counter; i++) {
      this.container.createEmbeddedView(this.template, new CounterDirectiveContext(i + 1));
    }
  }
}

class CounterDirectiveContext {
  constructor(public $implicit: any) { }
}
