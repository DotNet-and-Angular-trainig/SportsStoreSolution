import { Component } from '@angular/core';

@Component({
  selector: 'app-navfooter',
  templateUrl: './navfooter.component.html'
})

export class NavFooterComponent {
  getDateTime = () => {
    const date = new Date();
    const options = {
      year: 'numeric', month: 'short', day: 'numeric', weekday: 'short',
      hour: '2-digit', minute: '2-digit', second: '2-digit'
    };
    return date.toLocaleTimeString('en-IN', options);
  }

}
