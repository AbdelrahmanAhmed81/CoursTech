import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { catchError, Observable, Subject, tap, throwError } from 'rxjs';
import { AuthModel } from '../data-models/AuthModel';
import { AuthResponse } from '../data-models/AuthResponse';
// import { User } from '../data-models/User';
import { PassowrdValidator } from '../models/PasswordValidator';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/Account';
  // user: User | null = null;
  userDataArrived: Subject<void> = new Subject<void>();
  userDataRemoved: Subject<void> = new Subject<void>();

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

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

  isAuthinticated(): boolean {
    const token: string | null = this.getToken();
    return (token != null && !this.jwtHelper.isTokenExpired(token))
  }

  isAdmin(): boolean {
    const token = this.getToken();
    return (token != null && this.jwtHelper.decodeToken(token)['role'] == 'Admin')
  }

  getUserEmail(): string | null {
    const token = this.getToken();
    if (token) {
      return this.jwtHelper.decodeToken(token)['email']
    }
    return null;
  }

  logout(): void {
    localStorage.removeItem('jwt');
    this.userDataRemoved.next();
  }

  // fetchUserData(): void {
  //   debugger;
  //   let userData = localStorage.getItem('user');
  //   if (userData) {
  //     let parsedUser = JSON.parse(userData);
  //     let user: User = {
  //       email: parsedUser['email'],
  //       token: parsedUser['token'],
  //       expiration: new Date(parsedUser['expiration'])
  //     }
  //     if (!this.isTokenExpired(user)) {
  //       this.user = user
  //     }
  //     else {
  //       this.deleteUserData();
  //     }
  //   }
  // }


  private storeUserData(authResponse: AuthResponse): void {
    // let userData: User = {
    //   email: authResponse.email,
    //   token: authResponse.token,
    //   expiration: authResponse.expiration
    // }
    localStorage.setItem('jwt', authResponse.token);
    // this.user = userData;
    this.userDataArrived.next();
  }

  private getToken(): string | null {
    return localStorage.getItem("jwt");
  }

  // private isTokenExpired(user: User): boolean {
  //   return (!user.expiration || new Date() > user.expiration)
  // }

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