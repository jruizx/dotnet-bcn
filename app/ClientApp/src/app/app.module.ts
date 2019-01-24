import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductCatalogService } from './services/product-catalog.service';
import { AppMaterialModule } from './app-material.module';
import { routing } from './app.routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditProductCatalogComponent } from './product-catalog/edit-product-catalog/edit-product-catalog.component';
import { ProductCatalogComponent } from './product-catalog/product-catalog.component';
import { TopHeaderComponent } from './top-header/top-header.component';
import { OrdersComponent } from './orders/orders.component';
import { OrdersService } from './services/orders.service';
import { AddOrderComponent } from './orders/add-order/add-order.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductCatalogComponent,
    EditProductCatalogComponent,
    TopHeaderComponent,
    OrdersComponent,
    AddOrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    AppMaterialModule,
    routing
  ],
  providers: [
    ProductCatalogService,
    OrdersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
