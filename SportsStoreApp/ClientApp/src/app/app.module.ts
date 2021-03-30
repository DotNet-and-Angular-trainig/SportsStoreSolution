import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

// Both the components are added to a single module
//import { NavHeaderComponent } from './nav/navheader.component';
//import { NavFooterComponent } from './nav/navfooter.component';

import { NavModule } from './nav/nav.module';

@NgModule({
  declarations: [
    AppComponent
    //NavHeaderComponent, NavFooterComponent
  ],
  imports: [
    BrowserModule, NavModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
