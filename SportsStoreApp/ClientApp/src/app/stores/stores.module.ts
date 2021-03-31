import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { ModelModule } from '../models/models.module';

import { StoreComponent } from './store.component';

@NgModule({
  imports: [ModelModule, BrowserModule],
  declarations: [StoreComponent],
  exports: [StoreComponent]
})

export class StoresModule { }
