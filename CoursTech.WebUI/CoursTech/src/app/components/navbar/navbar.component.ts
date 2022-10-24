import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../Modules/AuthModule/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {
  @Input() isDark: boolean = false;
  @Output() changeMode: EventEmitter<boolean> = new EventEmitter<boolean>();
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
    this.fetchUserData();
  }

  ngOnDestroy(): void {
    this.userDataArriveSubscription?.unsubscribe();
    this.userDataRemoveSubscription?.unsubscribe();
  }

  onChangeMode() {
    this.isDark = !this.isDark;
    this.changeMode.emit(this.isDark);
  }

  logout() {
    this.authService.logout();
  }

  fetchUserData() {
    this.isAuthenticated = this.authService.isAuthinticated();
    this.isAdmin = this.authService.isAdmin();
    this.userEmail = this.authService.getUserEmail();
  }
}
