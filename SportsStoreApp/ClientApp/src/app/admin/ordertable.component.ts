import { Component } from '@angular/core';
import { Order } from '../models/order.model';
import { OrderRepository } from '../models/order.repository';

@Component({
  templateUrl: './ordertable.component.html'
})

export class OrderTableComponent {
  includeShipped: boolean = false;

  constructor(private orderRepository: OrderRepository) { }

  getOrders(): Order[] {
    return this.orderRepository.getOrders().filter(o => this.includeShipped || o.shipped === 'false');
  }

  markedShipped(order: Order) {
    order.shipped = 'true';
    this.orderRepository.updateOrder(order);
  }

  delete(id: number) {
    this.orderRepository.deleteOrder(id);
  }
}
