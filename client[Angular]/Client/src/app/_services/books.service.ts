import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BookList } from '../_models/booklist';
import { BookDetails } from '../_models/bookdetails';
import { Publisher } from '../_models/publisher';
import { Observable } from 'rxjs';

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

  getPublishers(){
    return this.http.get<Publisher[]>(this.apiUrl + 'books/publishers');
  }

  getBooksByPublisher(publisher: string): Observable<BookList[]> {
    const params = new HttpParams().set('publisher', publisher);
    return this.http.get<BookList[]>(`${this.apiUrl}books/filterpublishers`, { params });
  }
  
}
