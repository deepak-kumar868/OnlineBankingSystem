import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from '../models/account.model';

@Injectable({
  providedIn: 'root'
})
export class AccountDetailService {

  baseUrl:string="http://localhost:11646";
  constructor(private http:HttpClient) { }
    getAllAccount():Observable<Account[]>{
      return this.http.get<Account[]>(this.baseUrl+'/DisplayAllAccounts');
   }

   getAccount(id:number):Observable<Account>{
    return this.http.get<Account>(this.baseUrl+'ShowByAcctByCusId'+id);
   }

   updateAccount(accountDetails:Account):Observable<Account>{
    return this.http.put<Account>(this.baseUrl+'/UpdateAccount',accountDetails);
   }

   deleteAccount(id:Number):Observable<Account>{
    return this.http.delete<Account>(this.baseUrl+'/DeleteAccount/'+id);
   }

   addAccount(addAccountRequest:Account):Observable<Account>{
    //addAccountRequest.customerId=0;
    return this.http.post<Account>(this.baseUrl+'/AddAccount',addAccountRequest);
   }
}