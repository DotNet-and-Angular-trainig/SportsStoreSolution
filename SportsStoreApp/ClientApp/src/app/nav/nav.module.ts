import { NgModule } from '@angular/core';

import { NavHeaderComponent } from './navheader.component';
import { NavFooterComponent } from './navfooter.component';

@NgModule({
  imports: [],
  declarations: [NavHeaderComponent, NavFooterComponent],
  exports: [NavHeaderComponent, NavFooterComponent]
})

export class NavModule { }
