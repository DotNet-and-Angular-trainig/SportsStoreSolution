import { Component } from '@angular/core';

import { Cart } from '../models/cart.model';

@Component({
  templateUrl: './cartDetails.component.html'
})

export class CartDetailsComponent {
  constructor(public cart: Cart) { }
}
