import { Component, OnInit } from '@angular/core';
import { Product } from '../services/product';
import { ProductCatalogService } from '../services/product-catalog.service';

@Component({
  selector: 'product-catalog-component',
  templateUrl: './product-catalog.component.html'
})
export class ProductCatalogComponent implements OnInit {

  displayedColumns: string[] = ['name', 'description'];
  dataSource: Product[];

  constructor(private productCatalogService: ProductCatalogService) { }

  ngOnInit(): void {

    this.productCatalogService.getAll().subscribe(products => {
      this.dataSource = products;
    });

  }
}
