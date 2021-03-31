import { Injectable } from '@angular/core';
import { Product } from './product.model';
import { Observable, from } from 'rxjs';

@Injectable()

export class StaticDatasource {
  private products: Product[] = [
    new Product(1, 'Chai', 'Beverages', 'Tea with Milk', 20),
    new Product(2, 'Aniseed Syrup', 'Condiments', 'Good for Throat', 210),
    new Product(3, 'Konbu', 'Seafood', 'Dried Fish', 30),
    new Product(4, 'Geitost', 'Dairy Products', 'Soft Chocolate', 12),

    new Product(5, 'Coffee', 'Beverages', 'Coffee with Milk', 25),
    new Product(6, 'Vegie-spread', 'Condiments', 'Mixed Vegetables', 30),
    new Product(7, 'Ikura', 'Seafood', 'Sea fish', 120),
    new Product(8, 'Flotemysost', 'Dairy Products', 'Hard Chocolate', 40),

    new Product(9, 'Lime Soda', 'Beverages', 'Sweet Lime and Soda', 8),
    new Product(10, 'Louisiana Hot Spiced Okra', 'Condiments', 'Spiced Japanese Vegetables', 80),
    new Product(11, 'Inlagd Sill', 'Seafood', 'Squid with lots of sea leaves', 120),
    new Product(12, 'Camembert Pierrot', 'Dairy Products', 'Caramilk Chocolate ', 70),

    new Product(13, 'Butter Milk', 'Beverages', 'Cold Butter Milk', 25),
    new Product(14, 'Northwoods Cranberry Sauce', 'Condiments', 'Cranberry Sauce good for stomach', 50),
    new Product(15, 'Carnarvon Tigers', 'Seafood', 'Tiger fish', 220),
    new Product(16, 'Queso Cabrales', 'Dairy Products', 'Cabrales Chocolate', 40),

    new Product(13, 'Cold Coffee', 'Beverages', 'Cold Coffee with Milk', 30),
    new Product(16, 'Cadbury Silk', 'Dairy Products', 'Cadbury Silk Chocolate', 180)
  ];

  getProducts(): Observable<Product[]> {
    return from([this.products]);   
  }
}
