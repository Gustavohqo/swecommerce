import { Injectable } from '@angular/core';

@Injectable()
export class GlobalService {
  private serverURL : String;
  
  constructor() {
    this.serverURL = 'http://127.0.0.1:5000/api/';
   }

   public getServerURL() {
     return this.serverURL;
   }
}
