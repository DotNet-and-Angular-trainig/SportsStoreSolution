import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order.model';
import { StaticDatasource } from './static.datasource';
import { RestDatasource } from './rest.datasource';

@Injectable()

export class OrderRepository {
  private orders: Order[] = [];
  private loaded: boolean = false;

  //constructor(private dataSource: StaticDatasource)
  constructor(private dataSource: RestDatasource) { }

  loadOrders() {
    this.loaded = true;
    this.dataSource.getOrders().subscribe(
      (orders) => this.orders = orders,
      (err) => { console.log(`OrderRepository.loadOrders: error\n${err}`); }
    );
  }

  getOrders(): Order[] {
    if (!this.loaded) { this.loadOrders(); }
    return this.orders;
  }

  saveOrder(order: Order): Observable<Order> {
    return this.dataSource.saveOrder(order);
  }

  updateOrder(order: Order) {
    this.dataSource.updateOrder(order).subscribe(
      (od) => { this.orders.splice(this.orders.findIndex(o => o.orderId === order.orderId), 1, order); },
      (err) => { console.log(`OrderRepository.updateOrder: error\n${err}`); }
    );
  }

  deleteOrder(id: number) {
    this.dataSource.deleteOrder(id).subscribe(
      (order) => { this.orders.splice(this.orders.findIndex(od => id === od.orderId)); },
      (err) => { console.log(`OrderRepository.deleteOrder: error\n${err}`); }
    );
  }
}

