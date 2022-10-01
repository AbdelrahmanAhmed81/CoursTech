import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthModel } from '../data-models/AuthModel';
import { LoginResponseModel } from '../data-models/LoginResponseModel';
import { RegisterResponseModel } from '../data-models/RegisterResponseModel';
import { PassowrdValidator } from '../models/PasswordValidator';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/Authentication';

  constructor(private http: HttpClient) { }

  Register(authModel: AuthModel): Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(this.url + '/register', authModel);
  }

  Login(authModel: AuthModel): Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(this.url + '/login', authModel);
  }

  GetPasswordValidator(): Observable<PassowrdValidator> {
    return this.http.get<PassowrdValidator>(this.url + '/getPasswordValidator');
  }
}
