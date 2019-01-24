import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EditProductCatalogComponent } from './product-catalog/edit-product-catalog/edit-product-catalog.component';
import { ProductCatalogComponent } from './product-catalog/product-catalog.component';
import { OrdersComponent } from './orders/orders.component';
import { AddOrderComponent } from './orders/add-order/add-order.component';


export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'products', component: ProductCatalogComponent },
  { path: 'products/new', component: EditProductCatalogComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/add', component: AddOrderComponent }
];

export const appRoutingProviders: any[] = [];

export const routing = RouterModule.forRoot(routes);
