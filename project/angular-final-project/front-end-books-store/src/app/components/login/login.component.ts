import { Component} from '@angular/core';
import { Customer } from '../../shared/models/customer.model';
import { BookService } from '../../shared/services/book.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {
  currentCustomer:Customer;
  constructor(private bookService:BookService) { }
    loginSave(){
      this.bookService.loginCustomerValid();
  }
}
