import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountDetailService } from '../services/account-detail.service';
import { Account } from '../models/account.model';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-update-account',
  templateUrl: './update-account.component.html',
  styleUrls: ['./update-account.component.css']
})
export class UpdateAccountComponent implements OnInit {
  ud:any;
  constructor(private route:ActivatedRoute, private accountService:AccountDetailService,private router:Router,private http:HttpClient){}
  
  accountDetails : any

   ngOnInit():void{
    
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');
        console.log(id);
         this.http.get("http://localhost:11646/ShowByAcctByCusId/"+id).subscribe(data=>{
          console.log(data);
          this.accountDetails=data as []      
        });
      }})
        //if(id>0){
        //  this.accountService.getAccount(Number('id'))
        //  .subscribe({
        //    next:(response)=>{
        //      this.accountDetails=response;
        //      console.log(response);
        //    }
        //  })
        //}
      //}
    //})
  }
  updateAccount(){
    this.accountService.updateAccount(this.accountDetails)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['admin']);
      }
    })
  }

  deleteAccount(id:Number){
    this.accountService.deleteAccount(id)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['admin']);
      }
    })
  }
}
