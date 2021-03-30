import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { NavHeaderComponent } from './nav/navheader.component';
import { NavFooterComponent } from './nav/navfooter.component';

@NgModule({
  declarations: [
    AppComponent, NavHeaderComponent, NavFooterComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
