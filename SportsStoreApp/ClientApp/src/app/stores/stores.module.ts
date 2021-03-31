import { NgModule } from '@angular/core';

import { ModelModule } from '../models/models.module';

import { StoreComponent } from './store.component';

@NgModule({
  imports: [ModelModule],
  declarations: [StoreComponent],
  exports: [StoreComponent]
})

export class StoresModule { }
