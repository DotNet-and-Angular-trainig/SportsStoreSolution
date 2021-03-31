import { NgModule } from '@angular/core';

import { ProductRepository } from './product.repository';
import { StaticDatasource } from './static.datasource';

@NgModule({
  imports: [],
  providers: [ProductRepository, StaticDatasource]
})

export class ModelModule { }
