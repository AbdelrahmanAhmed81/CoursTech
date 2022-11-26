import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {
    if (this.authService.isAuthinticated()) {
      return true;
    }
    const refreshToken = this.authService.getRefreshToken();
    if (!refreshToken) {
      this.authService.logout();
      this.router.navigate(['login']);
      return false;
    }
    return this.authService.TryRefresh({ refreshToken: refreshToken });
  }
}
