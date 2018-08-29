import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Person } from './shared/model/person.model';
import { validateTZ } from './shared/validation/TZ.validator'
import { validateCountry } from './shared/validation/country.validator'
import { PostService } from './shared/services/post.service'
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'valid data';
  person: FormGroup;


 

  constructor(private fb: FormBuilder,private postService:PostService) {}
  ngOnInit() {
    this.person = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3),Validators.maxLength(15)]],    
      id: ['', [Validators.required, validateTZ]],    
      isMale: ['', [Validators.required]],    
      age: ['', Validators.compose([
        Validators.required, 
        Validators.max(120),
        Validators.min(0)
      ])],
      country: ['',Validators.compose([Validators.required, validateCountry])]
    });
  }
  onSubmit({ value, valid }: { value: Person, valid: boolean }) {
    console.log(value, valid);
   this.postService.send(value);   
  }
}
