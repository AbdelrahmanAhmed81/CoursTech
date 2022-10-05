import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from 'src/app/data-models/User';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {
  @Input() isDark: boolean = false;
  @Output() changeMode: EventEmitter<boolean> = new EventEmitter<boolean>();
  subscription: Subscription | undefined;

  isAuthenticated: boolean = false;
  user: User | null = null;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.user.subscribe(() => {
      this.fetchUserData();
    });
    debugger;
    this.fetchUserData();
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  onChangeMode() {
    this.isDark = !this.isDark;
    this.changeMode.emit(this.isDark);
  }

  fetchUserData() {
    this.user = this.authService.getUserData();
    this.isAuthenticated = !!this.user;
  }
}
