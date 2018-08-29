import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../model/person.model';
import { error } from 'util';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  send(user: Person) {
    this.http.post('https://angularprojectseldat.herokuapp.com/api/user ', user)
      .subscribe(data => {
        console.log(data);
        alert("added complited");
      },error=>{alert(error)});
  }

}
