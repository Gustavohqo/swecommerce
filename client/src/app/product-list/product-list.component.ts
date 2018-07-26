import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/service/product.service';
import { Router } from '@angular/router/';
import { ActivatedRoute } from '@angular/router/';
import { CartService } from 'src/app/service/cart.service';
import { CarItem } from 'src/app/model/CarItem';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
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
    console.log(product);
    this.router.navigate(['/product/'+ product.id]);
  }

  /**
   * Redirect to Product Registration view
   */
  public createProduct(){
    this.router.navigate(['/product']);
  }
}
