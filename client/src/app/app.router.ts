import { ModuleWithProviders } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProductListComponent } from "src/app/product-list/product-list.component";
import { ProductRegistrationComponent } from "src/app/product-registration/product-registration.component";
import { ShoppingCartComponent } from "src/app/shopping-cart/shopping-cart.component";
import { ProductManagementComponent } from "src/app/product-management/product-management.component";
import { StoreComponent } from "src/app/store/store.component";

export const appRoutes: Routes =[
    {path: '', component:StoreComponent},
    {path: 'product', component: ProductRegistrationComponent},
    {path: 'product/:id', component: ProductRegistrationComponent},
    {path: 'cart', component: ShoppingCartComponent},
    {path: 'management', component: ProductManagementComponent}
];