import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order.model';
import { StaticDatasource } from './static.datasource';
import { RestDatasource } from './rest.datasource';

@Injectable()

export class OrderRepository {
  private orders: Order[] = [];

  //constructor(private dataSource: StaticDatasource)
  constructor(private dataSource: RestDatasource) { }

  saveOrder(order: Order): Observable<Order> {
    return this.dataSource.saveOrder(order);
  }
}
