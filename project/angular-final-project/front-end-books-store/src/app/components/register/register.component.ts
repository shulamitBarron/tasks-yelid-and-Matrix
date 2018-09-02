import { Component } from '@angular/core';
import { Customer } from '../../shared/models/customer.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from '../../shared/services/post.service'



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{
 title = 'valid data';
  //currentCustomer:Customer;
  currentCustomer: FormGroup;

  registerSave(){
    localStorage.setItem("currentCustomer", JSON.stringify(this.currentCustomer));
}

  constructor(private fb: FormBuilder,private postService:PostService) {}
  ngOnInit() {
    this.currentCustomer = this.fb.group({
      firstName: ['first name', [
        Validators.required,Validators.pattern('^[a-zA-Z \-\']+'),Validators.minLength(3),Validators.maxLength(15)]],
      id: ['', [Validators.required, ]],    
      isMale: ['', [Validators.required]],    
      age: ['', Validators.compose([
        Validators.required, 
        Validators.max(120),
        Validators.min(0)
      ])],
      country: ['',Validators.compose([Validators.required, ])]
    });
  }
  onSubmit({ value, valid }: { value: Customer, valid: boolean }) {
    console.log(value, valid);
  // this.postService.send(value);   
  }
}


