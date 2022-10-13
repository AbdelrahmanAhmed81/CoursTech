import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
// import { User } from 'src/app/data-models/User';
import { AuthService } from 'src/app/services/auth.service';

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
  // user: User | null = null;
  userEmail: string | null = '';
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.userDataArriveSubscription = this.authService.userDataArrived.subscribe(() => {
      // this.storeUser();
      this.isAuthenticated = true;
      this.isAdmin = this.authService.isAdmin();
      this.userEmail = this.authService.getUserEmail();
    });
    this.userDataRemoveSubscription = this.authService.userDataRemoved.subscribe(() => {
      this.isAuthenticated = false;
    })
    this.isAuthenticated = this.authService.isAuthinticated();
    this.isAdmin = this.authService.isAdmin();
    this.userEmail = this.authService.getUserEmail();
    // this.authService.fetchUserData();
    // this.storeUser();
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
  // storeUser() {
  //   this.user = this.authService.user;
  //   this.isAuthenticated = !!this.user;
  // }
  // fetchUserData() {
  //   this.user = this.authService.getUserData();
  //   this.isAuthenticated = !!this.user;
  // }
}
