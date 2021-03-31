import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ModelModule } from '../models/models.module';
import { StoreComponent } from './store.component';
import { CounterDirective } from './counter.directive';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [ModelModule, BrowserModule, FormsModule],
  declarations: [StoreComponent, CounterDirective],
  exports: [StoreComponent]
})

export class StoresModule { }
