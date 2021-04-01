import { Component } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductRepository } from '../models/product.repository';

@Component({
  templateUrl: './producttable.component.html'
})

export class ProductTableComponent {
  constructor(private productRepository: ProductRepository) { }

  getProducts(): Product[] { return this.productRepository.getProducts(); }

  deleteProduct(id: number) { this.productRepository.deleteProduct(id); }
}
