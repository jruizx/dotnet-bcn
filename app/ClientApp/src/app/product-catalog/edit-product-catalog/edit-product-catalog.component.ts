import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ProductCatalogService } from '../../services/product-catalog.service';
import { Product } from '../../services/product';
import { Router } from '@angular/router';

@Component({
  selector: 'edit-product-catalog',
  templateUrl: './edit-product-catalog.component.html'
})
export class EditProductCatalogComponent implements OnInit {

  productForm: FormGroup;

  constructor(private productCatalogService: ProductCatalogService, private router: Router) {
    this.createForm();
  }

  ngOnInit(): void {
  }

  save(): void {
    var product = new Product();
    product.name = this.productForm.get('name').value;
    product.description = this.productForm.get('description').value;

    this.productCatalogService.add(product).subscribe(x => {
      this.router.navigate(['/products']);
    });
  }

  private createForm() {
    this.productForm = new FormGroup({
      name: new FormControl(''),
      description: new FormControl('')
    });
  }
}
