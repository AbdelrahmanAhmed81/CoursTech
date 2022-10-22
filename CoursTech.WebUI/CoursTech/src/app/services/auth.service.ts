import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, Observable, Subject, tap, throwError } from 'rxjs';
import { AuthModel } from '../data-models/AuthModel';
import { AuthTokens } from '../data-models/AuthTokens';
import { Claims } from '../data-models/Claims';
import { Roles } from '../data-models/Roles';
import { PassowrdValidator } from '../models/PasswordValidator';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/';
  private readonly accountUrl: string = this.url + 'Account';
  private readonly tokenUrl: string = this.url + 'Token';

  userDataArrived: Subject<void> = new Subject<void>();
  userDataRemoved: Subject<void> = new Subject<void>();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }

  Register(authModel: AuthModel): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(this.accountUrl + '/register', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  Login(authModel: AuthModel): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(this.accountUrl + '/login', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  private Refresh(tokens: AuthTokens): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(this.tokenUrl + '/refresh', tokens)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  tryRefreshTokens(): Observable<boolean> | boolean {
    const accessToken: string | null = this.getAccessToken();
    const refreshToken: string | null = this.getRefreshToken();
    if (!accessToken || !refreshToken) {
      this.logout();
      this.router.navigate(['login']);
      return false;
    }
    const credentials: AuthTokens = { accessToken: accessToken, refreshToken: refreshToken };
    return new Observable<boolean>((subsriber) => {
      this.Refresh(credentials).subscribe({
        next: (v) => { subsriber.next(true) },
        error: (e) => {
          this.logout();
          this.router.navigate(['login']);
          subsriber.next(false);
        }
      })
    });
  }

  GetPasswordValidator(): Observable<PassowrdValidator> {
    return this.http.get<PassowrdValidator>(this.url + '/getPasswordValidator');
  }

  isAuthinticated(): boolean {
    const token: string | null = this.getAccessToken();
    return (token != null && !this.jwtHelper.isTokenExpired(token))
  }

  isAdmin(): boolean {
    const token = this.getAccessToken();
    return (token != null && this.jwtHelper.decodeToken(token)[Claims.role] == Roles.admin)
  }

  getUserEmail(): string | null {
    const token = this.getAccessToken();
    if (token) {
      return this.jwtHelper.decodeToken(token)[Claims.email]
    }
    return null;
  }

  logout(): void {
    localStorage.removeItem('jwt');
    localStorage.removeItem('refresh');
    this.router.navigate(['/Home'])
    this.userDataRemoved.next();
  }

  private storeUserData(AuthTokens: AuthTokens): void {
    localStorage.setItem('jwt', AuthTokens.accessToken);
    localStorage.setItem('refresh', AuthTokens.refreshToken);
    this.userDataArrived.next();
  }

  private getAccessToken(): string | null {
    return localStorage.getItem("jwt");
  }

  private getRefreshToken(): string | null {
    return localStorage.getItem("refresh");
  }

  private handleError(errorResponse: HttpErrorResponse) {
    let message: string = '';
    console.log(errorResponse.error)
    switch (errorResponse.error) {
      case 'USER_ALREADY_EXISTS': {
        message = 'this email already in use'
        break;
      }
      case 'INVALID_PASSWORD': {
        message = 'this password doesn\'t match password rules'
        break;
      }
      case 'USER_NOT_FOUND': {
        message = 'user not found, try to sign in'
        break;
      }
      case 'WRONG_PASSWORD': {
        message = 'wrong password'
        break;
      }
      case 'ROLE_NOT_EXISTS': {
        message = 'role not found'
        break;
      }
      case 'UNKNOWN_ERROR':
      default: {
        message = 'unknown error occured, try again later'
        break;
      }
    }
    return throwError(() => message);
  }

}