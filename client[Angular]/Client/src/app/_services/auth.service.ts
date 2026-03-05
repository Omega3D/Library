import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  protected apiUrl = 'https://localhost:5001/api/account/';
  
  // Add a BehaviorSubject to track login status
  private loginStatusSubject = new BehaviorSubject<boolean>(this.isLoggedIn());
  loginStatus$ = this.loginStatusSubject.asObservable();

  constructor(private http: HttpClient) {this.checkInitialLoginStatus(); }

  register(user: any){
    return this.http.post<any>(`${this.apiUrl}register`, user);
  }

  login(login: any){
    return this.http.post<any>(`${this.apiUrl}login`, login);
  }

  saveUser(user: any): void {
    if (typeof localStorage !== 'undefined') {
      localStorage.setItem('user', JSON.stringify(user));
      this.loginStatusSubject.next(true);
    }
  }

  private checkInitialLoginStatus(): void {
    // Check if localStorage is available
    if (typeof localStorage !== 'undefined') {
      const user = localStorage.getItem('user');
      this.loginStatusSubject.next(!!user);
    }
  }

  getUser(): any {
    if (typeof localStorage !== 'undefined') {
      const user = localStorage.getItem('user');
      return user ? JSON.parse(user) : null;
    }
    return null;
  }

  isLoggedIn(): boolean {
    if (typeof localStorage !== 'undefined') {
      return !!localStorage.getItem('user');
    }
    return false;
  }

  logout(): void {
    if (typeof localStorage !== 'undefined') {
      localStorage.removeItem('user');
      this.loginStatusSubject.next(false);
    }
  }
}