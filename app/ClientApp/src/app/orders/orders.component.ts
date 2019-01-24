import { Component, OnInit } from '@angular/core';
import { Order } from '../services/order';
import { OrdersService } from '../services/orders.service';

@Component({
  selector: 'orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {


  displayedColumns: string[] = ['product', 'amount', 'date'];
  dataSource: Order[];

  constructor(private ordersService: OrdersService) { }

  ngOnInit(): void {

    this.ordersService.getAll().subscribe(orders => {
      this.dataSource = orders;
    });

  }
}
