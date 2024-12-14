import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BooksStateService {
  private publisherFilterSubject = new BehaviorSubject<string>('');
  publisherFilter$ = this.publisherFilterSubject.asObservable();

  setPublisherFilter(publisher: string): void {
    this.publisherFilterSubject.next(publisher);
  }
}
