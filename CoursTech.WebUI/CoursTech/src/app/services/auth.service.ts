import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthModel } from '../data-models/AuthModel';
import { LoginResponseModel } from '../data-models/LoginResponseModel';
import { RegisterResponseModel } from '../data-models/RegisterResponseModel';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url: string = 'https://localhost:7017/api/Authentication';

  constructor(private http: HttpClient) { }

  Register(authModel: AuthModel): Observable<RegisterResponseModel> {
    return this.http.post<RegisterResponseModel>(this.url + '/register', authModel);
  }

  Login(authModel: AuthModel): Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(this.url + '/login', authModel);
  }
}
