import { Component, OnInit } from '@angular/core';
import { BooksService } from '../_services/books.service';
import { BooksStateService } from '../_services/books-state.service';
import { BookList } from '../_models/booklist';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css'],
})
export class BooksListComponent implements OnInit {
  books: BookList[] = [];
  filteredBooks: BookList[] = [];
  isLoading: boolean = true;
  private filterSubscription!: Subscription;

  constructor(
    private booksService: BooksService,
    private booksStateService: BooksStateService
  ) {}

  ngOnInit(): void {
    this.getBooks();

    this.filterSubscription = this.booksStateService.publisherFilter$.subscribe(
      (publisher) => {
        this.filterBooks(publisher);
      }
    );
  }

  ngOnDestroy(): void {
    this.filterSubscription.unsubscribe();
  }

  getBooks() {
    this.isLoading = true;
    this.booksService.getBooks().subscribe(
      (response) => {
        this.books = response;
        this.filteredBooks = response;
        this.isLoading = false;
      },
      (error) => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  filterBooks(publisher: string) {
    if (publisher) {
      this.booksService.getBooksByPublisher(publisher).subscribe(
        (res) => {
          this.filteredBooks = res;
        },
        (error) => console.error(error)
      );
    } else {
      this.filteredBooks = [...this.books];
    }
  }
}
