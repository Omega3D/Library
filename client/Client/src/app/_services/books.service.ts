import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../_models/book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  apiUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getBooks(){
    return this.http.get<Book[]>(this.apiUrl + 'books');
  }
}
