import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean = false;
  username: string = '';
  private authSubscription: Subscription | null = null;

  constructor(private authService: AuthService, private router: Router) {}
  
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