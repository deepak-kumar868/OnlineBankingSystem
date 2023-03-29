import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseUrl:string="http://localhost:11646";
  constructor(private http:HttpClient) { }

  loginCustomer(loginCustomerRequest:Login):Observable<Login>{
    return this.http.post<Login>(this.baseUrl+'/ValidateUser',loginCustomerRequest);
  }
}
