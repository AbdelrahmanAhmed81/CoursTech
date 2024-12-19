import { environment } from "../../../../environments/environment"
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, exhaustMap, Observable, Subject, tap, throwError } from 'rxjs';
import jwt_deceode from 'jwt-decode'
import { AuthModel } from '../models/AuthModel';
import { AuthTokens } from '../models/AuthTokens';
import { Claims } from '../models/Claims';
import { Roles } from '../models/Roles';
import { PassowrdValidator } from '../models/PasswordValidator';

type TokenData = {
  email: string;
  role: string;
  exp: number;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = environment.API_URL;
  private readonly accountUrl: string = this.url + 'Account';
  private readonly tokenUrl: string = this.url + 'Token';
  private tokenData: TokenData | null = null;
  private accessToken: string | null = null;
  get token() {
    return this.accessToken;
  }

  userDataArrived: Subject<void> = new Subject<void>();
  userDataRemoved: Subject<void> = new Subject<void>();

  constructor(private http: HttpClient, private router: Router) { }

  // #region API_Requests
  Register(authModel: AuthModel): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(this.accountUrl + '/register', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  Login(authModel: AuthModel): Observable<AuthTokens> {
    return this.http.post<AuthTokens>(this.accountUrl + '/login', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  GetPasswordValidator(): Observable<PassowrdValidator> {
    return this.http.get<PassowrdValidator>(this.accountUrl + '/getPasswordValidator');
  }

  TryRefresh(authTokens: AuthTokens): Observable<boolean> {
    return this.http.post<AuthTokens>(this.tokenUrl + '/refresh', authTokens)
      .pipe(
        tap(resData => {
          this.storeUserData(resData)
        }),
        exhaustMap((tokens) => {
          return new Observable<boolean>((subscriber) => {
            if (tokens) {
              subscriber.next(true);
            }
            else {
              this.logout();
              this.router.navigate(['login']);
              subscriber.next(false);
            }
          })
        }),
        catchError(err => {
          this.logout();
          this.router.navigate(['login']);
          return throwError(() => err.error)
        })
      );
  }
  //#endregion

  isAuthinticated(): boolean {
    return (this.accessToken != null && !this.isTokenExpired())
  }

  isAdmin(): boolean {
    return (this.tokenData != null && this.tokenData.role == Roles.admin)
  }

  getUserEmail(): string | null {
    if (this.tokenData) {
      return this.tokenData.email
    }
    return null;
  }

  logout(): void {
    this.accessToken = null;
    localStorage.removeItem('refresh');
    this.router.navigate(['/Home'])
    this.userDataRemoved.next();
  }

  getRefreshToken(): string | null {
    return localStorage.getItem("refresh");
  }

  private storeUserData(authTokens: AuthTokens): void {
    if (authTokens.accessToken) {
      this.accessToken = authTokens.accessToken;
      const tokenPayload = this.decodeToken(authTokens.accessToken);
      this.tokenData = {
        email: tokenPayload[Claims.email],
        role: tokenPayload[Claims.role],
        exp: tokenPayload['exp']
      }

      localStorage.setItem('refresh', authTokens.refreshToken);
      this.userDataArrived.next();
    }
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

  private isTokenExpired(): boolean {
    return (new Date() > new Date(this.tokenData?.exp! * 1000));
  }

  private decodeToken(token: string): any {
    return jwt_deceode(token);
  }
}
