import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Product } from "./product";

@Injectable()
export class ProductCatalogService {

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>('api/product-catalog/products');
  }

  add(product: Product): Observable<Product> {
    return this.http.post<Product>('api/product-catalog/products', product);
  }
}
