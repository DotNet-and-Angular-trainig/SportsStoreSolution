import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ModelModule } from '../models/models.module';
import { StoreComponent } from './store.component';
import { CounterDirective } from './counter.directive';
import { CartDetailsComponent } from './cartDetails.component';

@NgModule({
  imports: [ModelModule, BrowserModule, FormsModule, RouterModule],
  declarations: [StoreComponent, CounterDirective, CartDetailsComponent],
  exports: [StoreComponent, CartDetailsComponent]
})

export class StoresModule { }
