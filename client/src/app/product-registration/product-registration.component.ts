import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/model/product';
import { ProductService } from 'src/app/service/product.service';
import { ActivatedRoute, Router } from '@angular/router/';
import { PromotionService } from 'src/app/service/promotion.service';


@Component({
  selector: 'app-product-registration',
  templateUrl: './product-registration.component.html',
  styleUrls: ['./product-registration.component.css']
})
export class ProductRegistrationComponent implements OnInit {
  private product;
  private validationErro;
  private promotions;

  private actual_state;
  private PRODUCT_STATES = {
    "CREATE":{
      buttonSave: true,
      title: "Cadastro de Produto"
    },
    "UPDATE":{
      buttonSave: false,
      buttonDelete: true,
      title: "Edição de Produto"
    }
  }

  constructor(private productService : ProductService,
              private promotionService : PromotionService,
              private route: ActivatedRoute,
              private router: Router) { 
    this.product = {};
    this.validationErro = {isInvalid: false};
    this.actual_state = this.PRODUCT_STATES.CREATE;
    this.promotions = [];
    this.promotionService.getPromotions().subscribe(
      next => this.promotions = next
    )
    
    this.route.params.subscribe(
      params => {
        const productId = params["id"];

        if(productId){
          return this.productService.getProduct(productId).subscribe(
            suc => {
              console.log(suc);
              this.actual_state = this.PRODUCT_STATES.UPDATE;
              this.product = suc},
            err => {
              console.log(err)
              this.router.navigate(['./product']);
            },
            () => {
              console.log(this.actual_state);
            }
          );
        }
      }
    );
  }

  ngOnInit() {}

  public saveProduct(){
    this.productService.save(this.product).subscribe(
      success => { 
        this.router.navigate(['../'])},
      error => {
        this.validationErro.true;
        this.validationErro.message = "Erro";
       })
  }

  public cancel() {
    this.router.navigate(['../']);
  }

  public deleteProduct() {
    this.productService.delete(this.product).subscribe(
      suc => {
        this.router.navigate(['../']);
      }
    )
  }
}
