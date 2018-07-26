import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GlobalService } from './global.service';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Cart } from 'src/app/model/Cart';


@Injectable()
export class CartService {
    private headers;
    private serverURL;
    private cartURL = "cart";

    private $cartAmmount = new Subject();

    public cart;

    constructor(private http: HttpClient,
                private config: GlobalService) {
        this.headers = new HttpHeaders();
        this.headers.set('Content-Type', 'application/json');
        this.serverURL = config.getServerURL();
    }
    
    public getCart() {
        return this.http.get<Cart>(this.serverURL + this.cartURL, {headers: this.headers});
    }

    public addToCart(cartItem) {
        return   this.http.put<Cart>(this.serverURL + this.cartURL, cartItem,{headers: this.headers});
    }
}