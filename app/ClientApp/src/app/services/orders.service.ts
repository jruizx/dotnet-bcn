import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Order } from "./order";

@Injectable()
export class OrdersService {

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Order[]> {
    return this.http.get<Order[]>('api/orders-api/orders');
  }

  add(order: Order): Observable<Order> {
    return this.http.post<Order>('api/orders-api/orders', order);
  }
}
