import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private baseUrl = 'https://localhost:5001/api/customer';

  constructor(private http: HttpClient) {}

  getCustomerDetails(userId: string): Observable<any> {
    return this.http.get<any>(`/api/customers/${userId}`);
  }
  
}
