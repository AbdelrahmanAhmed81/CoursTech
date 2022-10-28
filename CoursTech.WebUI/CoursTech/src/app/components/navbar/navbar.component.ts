import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { AuthService } from '../../Modules/AuthModule/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {
  @Input() isDark: boolean = false;
  @Input() isAuthenticated: boolean = false;
  @Input() isAdmin: boolean = false;
  @Input() userEmail: string | null = '';

  @Output() changeMode: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  onChangeMode() {
    this.isDark = !this.isDark;
    this.changeMode.emit(this.isDark);
  }

  logout() {
    this.authService.logout();
  }
}
