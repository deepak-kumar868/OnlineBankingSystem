import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Register } from '../models/register.model';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  baseUrl:string="http://localhost:11646";
  constructor(private http:HttpClient) { }

  registerCustomer(registerCustomerRequest:Register):Observable<Register>{
    return this.http.post<Register>(this.baseUrl+'/RegisterUser',registerCustomerRequest);
  }
}
