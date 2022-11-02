import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from './Modules/AuthModule/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'CourseTech';
  isDark: boolean = false;

  userDataArriveSubscription: Subscription | undefined;
  userDataRemoveSubscription: Subscription | undefined;
  isAuthenticated: boolean = false;
  isAdmin: boolean = false;
  userEmail: string | null = '';


  constructor(private authService: AuthService) { }
  ngOnInit(): void {
    this.userDataArriveSubscription = this.authService.userDataArrived.subscribe(() => {
      this.fetchUserData();
    });
    this.userDataRemoveSubscription = this.authService.userDataRemoved.subscribe(() => {
      this.isAuthenticated = false;
    })
    const refreshToken = this.authService.getRefreshToken();
    if (refreshToken) {
      this.authService.TryRefresh({ refreshToken: refreshToken }).subscribe({
        next: (val) => {
          if (val)
            this.fetchUserData();
        }
      });
    }
  }
  ngOnDestroy(): void {
    this.userDataArriveSubscription?.unsubscribe();
    this.userDataRemoveSubscription?.unsubscribe();
  }

  fetchUserData() {
    this.isAuthenticated = true;
    this.isAdmin = this.authService.isAdmin();
    this.userEmail = this.authService.getUserEmail();
  }

  onChangeMode(data: boolean) {
    this.isDark = data;
    document.body.classList.toggle('darkmode');
  }

}
