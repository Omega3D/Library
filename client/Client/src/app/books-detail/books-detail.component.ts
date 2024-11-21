import { Component } from '@angular/core';
import { BooksService } from '../_services/books.service';

@Component({
  selector: 'app-books-detail',
  templateUrl: './books-detail.component.html',
  styleUrl: './books-detail.component.css'
})
export class BooksDetailComponent {
  constructor(booksService: BooksService){

  }

  

}
