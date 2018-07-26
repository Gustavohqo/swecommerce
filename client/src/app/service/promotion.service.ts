import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { GlobalService } from "src/app/service/global.service";

@Injectable()
export class PromotionService {
    private headers;
    private serverURL;
    private promotionURL = "promotion";


    constructor(private http: HttpClient,
                private config: GlobalService) {
        this.headers = new HttpHeaders();
        this.headers.set('Content-Type', 'application/json');
        this.serverURL = config.getServerURL();
    }
    
    public getPromotions() {
        return this.http.get(this.serverURL + this.promotionURL, {headers: this.headers});
    }
}