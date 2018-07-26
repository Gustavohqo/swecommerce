import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/service/product.service';
import { CartService } from 'src/app/service/cart.service';
import { Router, ActivatedRoute } from '@angular/router/';
import { ToastrService } from 'ngx-toastr';

import { CarItem } from 'src/app/model/CarItem';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  private products;

  private selectedProduct;

  constructor(private productService : ProductService,
    private cartService : CartService,
    private route : ActivatedRoute,
    private router : Router,
    private toastr: ToastrService) { 
    
    this.selectedProduct = {};
    this.products = [];

    this.productService.getProducts().subscribe(
      data => {
       this.products = data
      }
    );
    }

  ngOnInit() {
  }

  /**
   * Select an item to put into Cart
   * @param product 
   */
  public selectItem(product) {
    const item = new CarItem(product.id, 1);
    this.cartService.addToCart(item).subscribe(
      next => {
        this.toastr.success('', "Item adicionado no carrinho", {
          timeOut:1000
        });
      }
    );
  }

}
