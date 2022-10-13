import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';


// @Injectable()
// export class InterceptorService implements HttpInterceptor {

//   constructor(private authService: AuthService) { }
//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     debugger;
//     let user = this.authService.user;
//     if (user && user.token) {
//       const newRequest = req.clone({ headers: new HttpHeaders().set("Authorization", `Bearer ${user.token}`) })
//       return next.handle(newRequest);
//     }
//     return next.handle(req);
//   }
// }
