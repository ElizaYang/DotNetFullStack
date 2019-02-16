import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpEvent,
  HttpRequest,
  HttpErrorResponse,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
// implement interface
// grub error in header from API to angular interceptor
export class ErrorInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse) {
          // Error1: if is bit authorized error
          if (error.status === 401) {
            return throwError(error.statusText);
          }
          // Error2: if is server custumize error/exception, info is in header
          const applicationError = error.headers.get("Application-Error");
          if (applicationError) {
            console.error(applicationError);
            return throwError(applicationError);
          }
          // Error3: model state error, http response is object
          const serverError = error.error;
          let modalStateErrors = "";
          if (serverError.errors && typeof serverError.errors === "object") {
            for (const key in serverError.errors) {
              if (serverError.errors[key]) {
                modalStateErrors += serverError.errors[key] + "\n";
              }
            }
          } else if (serverError && typeof serverError === "object") {
            for (const key in serverError) {
              if (serverError[key]) {
                modalStateErrors += serverError[key] + "\n";
              }
            }
          }
          // if neither case above
          return throwError(modalStateErrors || serverError || "Server Error");
        }
      })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};
