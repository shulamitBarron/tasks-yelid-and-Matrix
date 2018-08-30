import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Subject, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PackageService {
  
  subject = new Subject();
  subject1 = new Subject();
  constructor(private http: HttpClient) {
  }



  getCurrentListPackages(inputUser: string): Observable<any> {
    return this.http
      .get(`https://api.npms.io/v2/search/suggestions?q=${inputUser}&size=40`);

  }
  getCurrentDownload(packageString:string,startTime:Date,endTime:Date):Observable<any> {
    return this.http
    .get(`https://api.npmjs.org/downloads/point/${startTime}:${endTime}/${packageString}`);
  }




}
