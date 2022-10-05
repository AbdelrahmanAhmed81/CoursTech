import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, Subject, tap, throwError } from 'rxjs';
import { AuthModel } from '../data-models/AuthModel';
import { AuthResponse } from '../data-models/AuthResponse';
import { User } from '../data-models/User';
import { PassowrdValidator } from '../models/PasswordValidator';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/Account';
  user: Subject<void> = new Subject<void>();

  constructor(private http: HttpClient) { }

  Register(authModel: AuthModel): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(this.url + '/register', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  Login(authModel: AuthModel): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(this.url + '/login', authModel)
      .pipe(catchError(this.handleError), tap(resData => this.storeUserData(resData)));
  }

  GetPasswordValidator(): Observable<PassowrdValidator> {
    return this.http.get<PassowrdValidator>(this.url + '/getPasswordValidator');
  }

  getUserData(): User | null {
    let userData = localStorage.getItem('user');
    if (userData) {
      let user = JSON.parse(userData);
      if (!this.isUserTokenExpired(user))
        return user;
      else
        this.deleteUserData();
    }
    return null;
  }

  private storeUserData(authResponse: AuthResponse) {
    let userData = new User(authResponse.email, authResponse.token, authResponse.expiration)
    localStorage.setItem('user', JSON.stringify(userData));
    this.user.next();
  }

  private isUserTokenExpired(user: any) {
    return (!user['_expiration'] || new Date() > new Date(user['_expiration']));
  }

  private deleteUserData() {
    localStorage.removeItem('user');
    this.user.next();
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