import { Component } from '@angular/core';

import { Product } from '../models/product.model';
import { ProductRepository } from '../models/product.repository';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html'
})

export class StoreComponent {
  constructor(private productRepository: ProductRepository) { }

  get products(): Product[] {
    return this.productRepository.getProducts();
  }

  get categories(): string[] { return this.productRepository.getCategories(); }

}
