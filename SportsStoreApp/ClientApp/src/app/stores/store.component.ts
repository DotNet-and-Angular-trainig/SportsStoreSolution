import { Component } from '@angular/core';

import { Product } from '../models/product.model';
import { ProductRepository } from '../models/product.repository';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html'
})

export class StoreComponent {
  public selectedCategory: string = null!;
  public productsPerPage: number = 4;
  public selectedPage: number = 1;

  constructor(private productRepository: ProductRepository) { }

  get products(): Product[] {
    const pageIndex = ((this.selectedPage - 1) * this.productsPerPage);
    return this.productRepository.getProducts(this.selectedCategory).splice(pageIndex, this.productsPerPage);
    // return this.productRepository.getProducts(this.selectedCategory);// with category
    // return this.productRepository.getProducts();// First
  }

  get categories(): string[] { return this.productRepository.getCategories(); }

  changeCategory(newCategory?: string) {
    this.selectedCategory = newCategory!;
  }

  addProductToCart(product: Product) {
    console.log(`Selected Product will be added to the Cart: \n${JSON.stringify(product)}`);
  }

  changePage(newPage: number) { this.selectedPage = newPage; }

  changePageSize(newSize: number) {
    this.productsPerPage = newSize;
    this.changePage(1);
  }

  // this will return a array. array of numbers rather than the number itself (solution)
  get pageNumbers(): number[] {
    const result = Array(Math.ceil(this.productRepository.getProducts(this.selectedCategory).length / this.productsPerPage)).fill(0).map((x, i) => i + 1);
    console.log(`pageNumber: ${result}`);
    return result;
  }

}
