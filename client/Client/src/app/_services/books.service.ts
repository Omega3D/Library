import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BookList } from '../_models/booklist';
import { BookDetails } from '../_models/bookdetails';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  apiUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getBooks(){
    return this.http.get<BookList[]>(this.apiUrl + 'books/list');
  }

  getBookById(id: number){
    return this.http.get<BookDetails>(`${this.apiUrl}books/${id}`);
  }
}
