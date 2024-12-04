import { Component, OnInit } from '@angular/core';
import { BooksService } from '../_services/books.service';
import { BookList } from '../_models/booklist';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrl: './books-list.component.css'
})
export class BooksListComponent implements OnInit {
  ngOnInit(): void {
    this.getBooks();
  }
  books: BookList[] = [];

  constructor(private booksService: BooksService){}

  getBooks(){
    return this.booksService.getBooks().subscribe(
      response => {
        console.log(response);
        this.books = response
      },
      error => console.log(error),
    )
  }
}
