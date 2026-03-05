import { Component, OnInit } from '@angular/core';
import { BooksService } from '../_services/books.service';
import { ActivatedRoute } from '@angular/router';
import { BookDetails } from '../_models/bookdetails';
import { error } from 'console';

@Component({
  selector: 'app-books-detail',
  templateUrl: './books-detail.component.html',
  styleUrl: './books-detail.component.css'
})
export class BooksDetailComponent implements OnInit {
  bookDetails: BookDetails | null = null;
  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private booksService: BooksService
  ) {}

  ngOnInit(): void {
    const bookId = this.route.snapshot.params['id'];
    this.booksService.getBookById(bookId).subscribe({
      next: (details) => {
        this.bookDetails = details;
        this.isLoading = false;
      },
      error: (err) => {
        this.isLoading = false;
        console.log(err)
      },
    });
  }

  

}
