import { Injectable } from '@angular/core';
import { Customer } from '../models/customer.model';


@Injectable({
  providedIn: 'root'
})
export class BookService {


  constructor() {

  }
  isAnExistingCustomer(): Customer {
    return JSON.parse(localStorage.getItem('currentCustomer'));
  }
  loginCustomerValid():Customer {
    
   return 
  }
}
