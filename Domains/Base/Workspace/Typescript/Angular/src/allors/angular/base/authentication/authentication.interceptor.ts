import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import { Observable } from "rxjs/observable";
import { AuthenticationService } from "./authentication.service";

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
  constructor(private injector: Injector) {
  }

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    // Lazy inject AuthenticationService to prevent cyclic dependency on HttpClient
    const authenticationService = this.injector.get(AuthenticationService);
    const token = authenticationService.token;

    if (token) {
      const authReq = req.clone({
        headers: req.headers.set("Authorization", "Bearer " + token),
      });

      return next.handle(authReq);
    }

    return next.handle(req);
  }
}