import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { NavHeaderComponent } from './navheader.component';
import { NavFooterComponent } from './navfooter.component';
import { CartSummaryComponent } from '../stores/cartSummary.component';

@NgModule({
  imports: [BrowserModule, RouterModule],
  declarations: [NavHeaderComponent, NavFooterComponent, CartSummaryComponent],
  exports: [NavHeaderComponent, NavFooterComponent]
})

export class NavModule { }
