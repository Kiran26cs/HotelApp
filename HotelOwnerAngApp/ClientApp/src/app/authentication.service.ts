import { Injectable } from '@angular/core';
import { UserLogin, UserLoginResponse, RegisterUser, RegisterUserResponse } from './Models/UserComponentViewModel';
import { HttpClient, HttpErrorResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/Operators';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';
import { strictEqual } from 'assert';
import { DatePipe } from '@angular/common'

@Injectable()
export class AuthenticationService {
  private processURL: string;
  public userLogResp: UserLoginResponse;
  public authServiceApiURL = 'https://localhost:44335/api/Auth';
  constructor(private _http: HttpClient) { }

  //login(loginDetail: UserLogin): Observable<UserLoginResponse> {
  //  this.processURL = `${this.authServiceApiURL}/Login`;
  //  const headers = { 'content-type': 'application/json' }
  //  const loginDetailJson = JSON.stringify(loginDetail);
  //  return this._http.post<UserLoginResponse>(this.processURL, loginDetailJson, { headers: headers })
  //    .pipe(map(userDataResp => {
  //      if (userDataResp != null && userDataResp.Token != null) {
  //        localStorage.setItem('letohppa_vrsetacitnehtua', JSON.stringify(userDataResp));
  //      }        
  //      return userDataResp;
  //    }));
  //}

  login(loginDetail: UserLogin): Observable<any>{
    this.processURL = `${this.authServiceApiURL}/Login`;
    const headers = { 'content-type': 'application/json' }
      const loginDetailJson = JSON.stringify(loginDetail);
      return this._http.post(this.processURL, loginDetailJson, { headers: headers })
  }

  logout() {
    if (this.isAthorized) {
      localStorage.removeItem('letohppa_vrsetacitnehtua');
    }
  }

  isAthorized() {
    return localStorage.getItem('letohppa_vrsetacitnehtua') != null || localStorage.getItem('letohppa_vrsetacitnehtua') != undefined;
  }

  createUser(registerDetail: RegisterUser): Observable<any> {
    this.processURL = `${this.authServiceApiURL}/CreateUser`;
    const headers = { 'content-type': 'application/json' }
    const registerDetailJson = JSON.stringify(registerDetail);
    return this._http.post(this.processURL, registerDetailJson, { headers: headers });
  }

  handleCatchErrors(error: HttpErrorResponse) {
    return Observable.throw(error.message);
  }
}
