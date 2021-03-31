import { Component } from '@angular/core';

import { Cart } from '../models/cart.model';

@Component({
  selector: 'app-cartsummary',
  templateUrl: './cartSummary.component.html'
})

export class CartSummaryComponent {
  constructor(public cart: Cart) { }
}
