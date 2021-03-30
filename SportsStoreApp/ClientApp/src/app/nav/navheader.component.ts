import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-navheader',
  templateUrl: './navheader.component.html'
})

export class NavHeaderComponent {
  @Input() title: any;
}
