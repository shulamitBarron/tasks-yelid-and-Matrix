import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer.model';
import { error } from 'util';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  addCustomer(customer: Customer) {
    //this.http.post('https://angularprojectseldat.herokuapp.com/api/user ', user)
    this.http.post('http://api/user ', customer)     
    .subscribe(data => {
        console.log(data);
        alert("added complited");
      },error=>{alert(error)});
  }
}
