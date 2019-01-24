import { Component, OnInit } from '@angular/core';
import { ProductCatalogService } from '../../services/product-catalog.service';
import { OrdersService } from '../../services/orders.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { Product } from '../../services/product';
import { filter, map } from 'rxjs/operators';
import { Order } from '../../services/order';
import { Router } from '@angular/router';

@Component({
  selector: 'add-order',
  templateUrl: './add-order.component.html'
})
export class AddOrderComponent implements OnInit {

  orderForm: FormGroup;
  filteredProducts: Observable<Product[]>;

  constructor(
    private router: Router,
    private productCatalogService: ProductCatalogService,
    private ordersService: OrdersService) {
    this.createForm();
  }

  ngOnInit(): void {
  }

  save(): void {
    var order = new Order();
    order.amount = this.orderForm.get('amount').value;
    order.productId = this.orderForm.get('product').value.id;
    order.productName = this.orderForm.get('product').value.name;

    this.ordersService.add(order).subscribe(() => {
      this.router.navigate(['/orders']);
    });
  }

  displayProductName(product?: Product): string | undefined {
    return product ? product.name : undefined;
  }


  private createForm(): void {

    var productControl = new FormControl();

    productControl.valueChanges.subscribe(term => {

      this.filteredProducts =
        this.productCatalogService
          .getAll()
          .pipe(
            map(products => products.filter(product => product.name.toLowerCase().indexOf(term.toLowerCase()) != -1))
          )
    });

    this.orderForm = new FormGroup({
      amount: new FormControl(0),
      product: productControl
    })
  }
}
