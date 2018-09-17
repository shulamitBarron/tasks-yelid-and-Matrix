import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { BookRootObject, Book } from './../models/book.model';
import { config } from '../models/app-config';

@Injectable()
export class BookService {

    constructor(private httpClient: HttpClient) { }


    getBooksInfoByQuery(query: string = "a"): Observable<BookRootObject> {
        return this.httpClient
            .get<BookRootObject>(config.baseUrl+`/api/book/name/${query}`);
    }


    getBookInfo(id: string): Observable<Book> {
        return this.httpClient
            .get<Book>(config.baseUrl+`/api/book/id/${id}`);
    }
}