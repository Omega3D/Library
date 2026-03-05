import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Subscription } from 'rxjs';
import { CustomerService } from '../_services/customer.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {
  isLoggedIn: boolean = false;
  username: string = '';

  customer: any = null;
  isCustomerLoading: boolean = false;
  
  private authSubscription: Subscription | null = null;

  constructor(private authService: AuthService, private router: Router,private customerService: CustomerService) {}
  
  ngOnInit(): void {
    // Subscribe to login status changes
    this.authSubscription = this.authService.loginStatus$.subscribe(status => {
      this.isLoggedIn = status;
      if (status) {
        const user = this.authService.getUser();
        this.username = user ? user.username : '';
      } else {
        this.username = '';
      }
    });
  }

  loadCustomerDetails(): void {
    this.isCustomerLoading = true; // Початок завантаження
    const userId = localStorage.getItem('userId'); // Отримання userId із LocalStorage
  
    if (userId) {
      this.customerService.getCustomerDetails(userId).subscribe({
        next: (customer) => {
          this.customer = customer;
          this.isCustomerLoading = false; // Завершення завантаження
        },
        error: (err) => {
          console.error('Error fetching customer details', err);
          this.isCustomerLoading = false; // Завершення завантаження при помилці
        }
      });
    } else {
      console.error('No userId found in localStorage');
      this.isCustomerLoading = false; // Завершення завантаження, якщо userId відсутній
    }
  }
  
  



  ngOnDestroy(): void {
    if (this.authSubscription) {
      this.authSubscription.unsubscribe();
    }
  }

  updateLoginStatus(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
    const user = this.authService.getUser();
    this.username = user ? user.username : '';
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/home']);
  }
}