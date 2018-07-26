import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { GlobalService } from 'src/app/service/global.service';
import { concat } from 'rxjs/internal/observable/concat';
import { Product } from 'src/app/model/product';

@Injectable()
export class ProductService {
  private headers;
  private serverURL;

  constructor(private http: HttpClient,
              private config: GlobalService) { 
    this.headers = new HttpHeaders()
    this.headers.set('Content-Type', 'application/json');
    this.serverURL = config.getServerURL();
  }

  public getProducts() {
    console.log(this.serverURL)
    return this.http.get(this.serverURL + 'product',
    {headers: this.headers});
  }

  public getProduct(id) {
    return this.http.get<Product>(this.serverURL + 'product/' + id, {headers: this.headers})
  }

  public save(product) {
    if(!product.id){
      return this.http.post<Product>(this.serverURL + 'product',product, {headers: this.headers})  
    }
    
    return this.http.put<Product>(this.serverURL + 'product/' + product.id,product, {headers: this.headers})  
  }

  public delete(product) {
    return this.http.delete<Product>(this.serverURL + 'product/' + product.id,{headers: this.headers});
  }

}
