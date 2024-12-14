import { Component, OnInit } from '@angular/core';
import { BooksStateService } from '../_services/books-state.service';
import { BooksService } from '../_services/books.service';
import { Publisher } from '../_models/publisher';

@Component({
  selector: 'app-books-filter',
  templateUrl: './books-filter.component.html',
  styleUrls: ['./books-filter.component.css'],
})
export class BooksFilterComponent implements OnInit {
  publishers: Publisher[] = [];
  selectedPublisher: string = '';

  constructor(
    private booksService: BooksService,
    private booksStateService: BooksStateService
  ) {}

  ngOnInit(): void {
    this.getPublishers();
  }

  getPublishers() {
    this.booksService.getPublishers().subscribe(
      (response) => {
        this.publishers = response;
      },
      (error) => console.error(error)
    );
  }

  onPublisherSelect(publisherName: string): void {
    this.selectedPublisher = publisherName;
    this.booksStateService.setPublisherFilter(publisherName);
  }

  clearFilter(): void {
    this.selectedPublisher = '';
    this.booksStateService.setPublisherFilter('');
  }
}
