import { Injectable } from '@angular/core';
import { Cart } from './cart.model';

@Injectable()

export class Order {
  public orderId!: number;
  public name!: string;
  public city!: string;
  public state!: string;
  public zip!: string;
  public country!: string;
  public giftwrap!: string;
  public shipped!: string;

  constructor(public cart?: Cart) { }

  clear() {
    this.orderId = 0;
    this.name = this.city = this.state = this.country = '';
    this.giftwrap = 'false';
    this.shipped = 'false';
    this.cart!.clear();
  }
}
