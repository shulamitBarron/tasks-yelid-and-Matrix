import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../model/person.model';
import { error } from 'util';
import {Md5} from 'ts-md5/dist/md5';
import { async } from 'rxjs/internal/scheduler/async';

@Injectable({
  providedIn: 'root'
})
export class PostService {
constructor(private http: HttpClient){}
 URL="http://localhost:3000/";
 

  login(user: Person) {
    
   user.password= Md5.hashStr(user.password).toString();
    this.http.post(this.URL+"login", user)
      .subscribe(data => {
        console.log(data);
        alert("login complited");
      },error=>{});
  }


  register(user: Person) {
    this.http.get(this.URL+"register", user)//header      
      .subscribe(data => {
        console.log(data);
        alert("added complited");
      },error=>{});
  }
}
