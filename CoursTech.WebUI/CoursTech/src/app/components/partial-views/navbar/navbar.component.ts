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
  user: User | undefined;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.subscription = this.authService.user?.subscribe(user => {
      this.isAuthenticated = !!user;
      this.user = user;
    });
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  onChangeMode() {
    this.isDark = !this.isDark;
    this.changeMode.emit(this.isDark);
  }
}
