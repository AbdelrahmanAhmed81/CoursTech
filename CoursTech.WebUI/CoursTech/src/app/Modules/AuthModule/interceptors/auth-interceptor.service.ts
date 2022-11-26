import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
    constructor(private authSerivce: AuthService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.authSerivce.isAuthinticated()) {
            const modRequest = req.clone({
                headers: new HttpHeaders({ 'Authorization': 'Bearer ' + this.authSerivce.token })
            })
            return next.handle(modRequest);
        }
        return next.handle(req);
    }

}