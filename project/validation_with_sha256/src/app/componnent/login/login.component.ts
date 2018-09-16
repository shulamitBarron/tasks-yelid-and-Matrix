import { Component } from '@angular/core';
import { FormGroup,  FormControl, ValidatorFn } from '@angular/forms';
import { Person } from '../../shared/model/person.model';
import { PostService } from '../../shared/services/post.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  formGroup: FormGroup;
  obj: typeof Object = Object;
  currentCustomer: Person;
  constructor(private postService: PostService) {
    let formGroupConfig = {
      userName: new FormControl("", this.createValidatorArr("name", 3, 15, /^[A-Za-z ]+$/)),
      password: new FormControl("", this.createValidatorArr("password", 5, 10))
    };

    this.formGroup = new FormGroup(formGroupConfig);
  }
  createValidatorArr(cntName: string, min: number, max: number, pattern?: RegExp): Array<ValidatorFn> {
    return [
      f => !f.value ? { "val": `${cntName} is required` } : null,
      f => f.value && pattern && !f.value.match(pattern) ? { "val": `${cntName} is contain only english letter` } : null,
      f => f.value && f.value.length > max ? { "val": `${cntName} is max ${max} chars` } : null,
      f => f.value && f.value.length < min ? { "val": `${cntName} is min ${min} chars` } : null
    ];
  }
  submitLoginSave() {
    this.currentCustomer  = this.formGroup.value;
    this.postService.login(this.currentCustomer);
    
  }
  register(){
    this.currentCustomer  = this.formGroup.value;
    this.postService.register(this.currentCustomer);
  }
}

