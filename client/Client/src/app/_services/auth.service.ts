import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  protected apiUrl = 'https://localhost:5001/api/account/';

  constructor(private http: HttpClient) { }

  register(user: any){
    return this.http.post<any>(`${this.apiUrl}register`, user);
  }

  login(login: any){
    return this.http.post<any>(`${this.apiUrl}login`, login);
  }
}
