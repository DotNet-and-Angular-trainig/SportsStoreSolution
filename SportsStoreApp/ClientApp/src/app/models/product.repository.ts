import { Injectable } from '@angular/core';
import { Product } from './product.model';
import { StaticDatasource } from './static.datasource';

@Injectable()

export class ProductRepository {
  private products: Product[] = [];
  private categories: string[] = [];

  constructor(private dataSource: StaticDatasource) {
    dataSource.getProducts()
      .subscribe(
        (data) => {
          this.products = data;
          this.categories = data.map(p => p.category).filter((c, index, array) => array.indexOf(c) === index).sort() as string[];
        },
        (err) => { console.log(`Error from dataSource.getProducts().subscribe() -> \n${err}`); },
        () => { console.log(`dataSource.getProducts().subscribe() -> work completed`); }
      );
  }

  getProducts(category: string | null = null): Product[] {
    return this.products.filter(c => category == null || category === c.category);
  }

  getProduct = (id: number) => this.products.find(p => p.productId == id) as Product;

  getCategories = () => this.categories;
}
