import { Component } from '@angular/core';

import { Product } from '../models/product.model';
import { ProductRepository } from '../models/product.repository';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html'
})

export class StoreComponent {
  public selectedCategory: string = null!;

  constructor(private productRepository: ProductRepository) { }

  get products(): Product[] {
    return this.productRepository.getProducts(this.selectedCategory);// with category
    // return this.productRepository.getProducts();// First
  }

  get categories(): string[] { return this.productRepository.getCategories(); }

  changeCategory(newCategory?: string) {
    this.selectedCategory = newCategory!;
  }

  addProductToCart(product: Product) {
    console.log(`Selected Product will be added to the Cart: \n${JSON.stringify(product)}`);
  }

}
