import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { NavModule } from './nav/nav.module';
import { StoreComponent } from './stores/store.component';
import { StoresModule } from './stores/stores.module';
import { CartDetailsComponent } from './stores/cartDetails.component';
import { CheckoutComponent } from './stores/checkout.component';
import { StoreFirstGuard } from './storeFirst.guard';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule, NavModule, StoresModule,
    RouterModule.forRoot([
      { path: 'store', component: StoreComponent, canActivate: [StoreFirstGuard] },
      { path: 'cart', component: CartDetailsComponent, canActivate: [StoreFirstGuard] },
      { path: 'checkout', component: CheckoutComponent, canActivate: [StoreFirstGuard] },
      //child
      { path: 'admin', loadChildren: () => import('./admin/admin.module').then(l => l.AdminModule) },
      { path: '**', redirectTo: '/store' }
    ])
  ],
  providers: [StoreFirstGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
