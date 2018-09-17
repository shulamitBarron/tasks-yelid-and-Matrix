import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { CountryBasic } from './../models/countryBasic.model';
import {config} from './../models/app-config'
@Injectable()
export class CountryService {

    constructor(private httpClient: HttpClient) { }

    getCountriesInfo(): Observable<CountryBasic[]> {
        return this.httpClient
            .get<CountryBasic[]>(config.baseUrl+`/api/country`);
    }

}