import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, from } from 'rxjs';
import { Product } from './product.model';
import { Order } from './order.model';


// .Net WebAPI URL
//http://localhost:7000/api/{product/order/orderdetail}
//https://localhost:44362/api/product
// Angular URL
//http://localhost:4200

const PROTOCOL = 'http';
const PORT = '7000';

@Injectable()

export class RestDatasource {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = `${PROTOCOL}://${location.hostname}:${PORT}/api`;
    console.log(`DateTime: ${new Date()} --- Base URL: ${this.baseUrl}`);
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/product`);
  }

  saveProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.baseUrl}/product`, product);
  }

  updateProduct(product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.baseUrl}/product`, product);
  }

  deleteProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(`${this.baseUrl}/product/${id}`);
  }

  getOrders(): Observable<Order[]> { return this.http.get<Order[]>(`${this.baseUrl}/order`);}

  saveOrder(order: Order): Observable<Order> {
    console.log(`From RestDatasource (Full data with Cart):\n${JSON.stringify(order)}`);
    return from([order]);
    // return this.http.post<Order>(`${this.baseUrl}/order`, order);
  }

  deleteOrder(id: number): Observable<Order> {
    return this.http.delete<Order>(`${this.baseUrl}/order/${id}`);
  }

  updateOrder(order: Order): Observable<Order> {
    return this.http.put<Order>(`${this.baseUrl}/order/${order.orderId}`, order);
  }
}
