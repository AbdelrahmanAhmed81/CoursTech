import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, Observable, Subject, tap, throwError } from 'rxjs';
import { AuthModel } from '../models/AuthModel';
import { AuthTokens } from '../models/AuthTokens';
import { Claims } from '../models/Claims';
import { Roles } from '../models/Roles';
import { PassowrdValidator } from '../models/PasswordValidator';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/';
  private readonly accountUrl: string = this.url + 'Account';
  private readonly tokenUrl: string = this.url + 'Token';
  private static accessToken: string | null = null;

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

  tryRefreshTokens(navigateToLogin: boolean): Observable<boolean> {
    const refreshToken: string | null = this.getRefreshToken();
    return new Observable<boolean>((subsriber) => {
      if (!refreshToken) {
        if (navigateToLogin) this.router.navigate(['login']);
        subsriber.next(false);
      }
      else {
        this.Refresh({ refreshToken: refreshToken }).subscribe({
          next: (v) => { subsriber.next(true) },
          error: (e) => {
            this.logout();
            this.router.navigate(['login']);
            subsriber.next(false);
          }
        })
      }
    });
  }

  GetPasswordValidator(): Observable<PassowrdValidator> {
    return this.http.get<PassowrdValidator>(this.accountUrl + '/getPasswordValidator');
  }

  isAuthinticated(): boolean {
    const token: string | null = AuthService.getAccessToken();
    return (token != null && !this.jwtHelper.isTokenExpired(token))
  }

  isAdmin(): boolean {
    const token = AuthService.getAccessToken();
    return (token != null && this.jwtHelper.decodeToken(token)[Claims.role] == Roles.admin)
  }

  getUserEmail(): string | null {
    const token = AuthService.getAccessToken();
    if (token) {
      return this.jwtHelper.decodeToken(token)[Claims.email]
    }
    return null;
  }

  logout(): void {
    // localStorage.removeItem('jwt');
    AuthService.accessToken = null;
    localStorage.removeItem('refresh');
    this.router.navigate(['/Home'])
    this.userDataRemoved.next();
  }

  private storeUserData(authTokens: AuthTokens): void {
    // localStorage.setItem('jwt', AuthTokens.accessToken);
    if (authTokens.accessToken) {
      AuthService.accessToken = authTokens.accessToken;
      localStorage.setItem('refresh', authTokens.refreshToken);
      this.userDataArrived.next();
    }
  }

  static getAccessToken(): string | null {
    // return localStorage.getItem("jwt");
    return AuthService.accessToken;
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