import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'
import { RouterModule, Routes } from '@angular/router';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductRegistrationComponent } from './product-registration/product-registration.component'
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { NavbarComponent } from './navbar/navbar.component';

import { GlobalService } from './service/global.service'
import { ProductService } from './service/product.service';
import { CartService } from './service/cart.service';
import { PromotionService } from './service/promotion.service';

import { appRoutes } from './app.router';
import { ProductManagementComponent } from './product-management/product-management.component';
import { StoreComponent } from './store/store.component';

@NgModule({ 
  declarations: [
    AppComponent,
    ProductComponent,
    ProductListComponent,
    ProductRegistrationComponent,
    ShoppingCartComponent,
    NavbarComponent,
    ProductManagementComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    CurrencyMaskModule,
    FormsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    GlobalService,
    ProductService,
    CartService,
    PromotionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
