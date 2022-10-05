import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { exhaustMap, Observable, take } from 'rxjs';
import { AuthService } from './auth.service';


@Injectable()
export class InterceptorService implements HttpInterceptor {

  constructor(private authService: AuthService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // return this.authService.user.pipe(
    //   take(1),
    //   exhaustMap(user => {
    //     console.log(user)
    //     if (user) {
    //       const newRequest = req.clone({ headers: new HttpHeaders().set("Authorization", `Bearer ${user?.token}`) })
    //       return next.handle(newRequest);
    //     }
    //     return next.handle(req);
    //   }));
    debugger;
    let user = this.authService.getUserData();
    if (user) {
      const newRequest = req.clone({ headers: new HttpHeaders().set("Authorization", `Bearer ${user['_token']}`) })
      return next.handle(newRequest);
    }
    return next.handle(req);
  }
}
