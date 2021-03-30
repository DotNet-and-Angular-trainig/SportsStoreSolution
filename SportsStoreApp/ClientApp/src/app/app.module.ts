import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

// Both the components are added to a single module
//import { NavHeaderComponent } from './nav/navheader.component';
//import { NavFooterComponent } from './nav/navfooter.component';
//import { StoreComponent } from './stores/store.component';

import { NavModule } from './nav/nav.module';
import { StoresModule } from './stores/stores.module';


@NgModule({
  declarations: [
    AppComponent
    //NavHeaderComponent, NavFooterComponent, StoreComponent
  ],
  imports: [
    BrowserModule, NavModule, StoresModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
