import { Component } from '@angular/core';
import { Customer } from '../../shared/models/customer.model';
import { BookService } from '../../shared/services/book.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  currentCustomer: Customer = {};
 
  IsAnExistingCustomer: boolean;
  constructor(private bookService: BookService) {
   this.currentCustomer.firstName ="guest";
   this.currentCustomer= this.bookService.isAnExistingCustomer();
  }



}
