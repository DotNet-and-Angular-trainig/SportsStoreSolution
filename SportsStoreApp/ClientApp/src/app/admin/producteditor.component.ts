import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Product } from '../models/product.model';
import { ProductRepository } from '../models/product.repository';

@Component({
  templateUrl: './producteditor.component.html'
})

export class ProductEditorComponent {
  editing: boolean = false;
  product: Product = new Product();

  constructor(private productRepository: ProductRepository, private router: Router, activeRoute: ActivatedRoute) {
    this.editing = activeRoute.snapshot.params['mode'] === 'edit';
    if (this.editing) {
      Object.assign(this.product, productRepository.getProduct(activeRoute.snapshot.params['id']));
    }
  }

  save(form: NgForm) {
    this.productRepository.saveProduct(this.product);
    this.router.navigateByUrl('/admin/main/products');
  }

}
