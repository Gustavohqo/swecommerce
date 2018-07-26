import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/service/cart.service';
import { Cart } from 'src/app/model/Cart';
import { ProductService } from 'src/app/service/product.service';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';
import { Router, ActivatedRoute } from '@angular/router/';

import * as _ from 'lodash';
 
@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit, OnChanges {
  public cart : Cart;
  public changingCart : Cart;

  public products;

  constructor(
    private cartService : CartService,
    private productService : ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.cart = new Cart({}, 0, 0, 0);
    this.getCart();
   }

  ngOnInit() {
  }

  ngOnChanges(changes){
    console.log(changes);
  }

  private getCart(){
    return this.cartService.getCart().subscribe(
      next => {
        this.cart = next;
        this.changingCart = _.cloneDeep(this.cart, true);
        this.products = Object.values(this.changingCart.products);
      }
    )
  }

  public getProducName(item) {
      let product = undefined;
      return this.productService.getProduct(item.productID).subscribe(
        next => next.name
      )
  }


  public updateItem(item) {
    const original = this.cart.products[item.productID];
    var newItem = _.cloneDeep(item, true);
    newItem.amount = item.amount - original.amount

    this.cartService.addToCart(newItem).subscribe(
      next => { 
        this.cart = next;
        this.changingCart = _.cloneDeep(this.cart, true);
        this.products = Object.values(this.changingCart.products);
        item.change = false;
      }
    );
  }
}
