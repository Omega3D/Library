import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BooksListComponent } from './books-list/books-list.component';
import { HttpClientModule } from '@angular/common/http';
import { BooksDetailComponent } from './books-detail/books-detail.component';
import { NavComponent } from './nav/nav.component';
import { BooksFilterComponent } from './books-filter/books-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    BooksListComponent,
    BooksDetailComponent,
    NavComponent,
    BooksFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
