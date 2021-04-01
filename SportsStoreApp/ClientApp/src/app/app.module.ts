import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { NavModule } from './nav/nav.module';
import { StoreComponent } from './stores/store.component';
import { StoresModule } from './stores/stores.module';
import { CartDetailsComponent } from './stores/cartDetails.component';
import { CheckoutComponent } from './stores/checkout.component';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule, NavModule, StoresModule,
    RouterModule.forRoot([
      { path: 'store', component: StoreComponent },
      { path: 'cart', component: CartDetailsComponent },
      { path: 'checkout', component: CheckoutComponent },
      { path: '**', redirectTo: '/store' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
