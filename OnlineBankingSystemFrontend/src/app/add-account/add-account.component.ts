import { Component,OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Account } from '../models/account.model';
import { AccountDetailService } from '../services/account-detail.service';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {
  addAccountRequest:Account={
    customerId:0,
    customerName:'',
    customerAddress:'',
    customerPhNo:'',
    customerAge:0,
    dob:new Date,
    accountNo:'',
    // ifsc:'',
    accountTypeId:0,
    balance:0,
    branch:'',
    customerType:''
  }
  ngOnInit(): void {
    
  }

  constructor(private accountService:AccountDetailService,private router:Router){}
  addAccount(){
    this.accountService.addAccount(this.addAccountRequest)
    .subscribe({
      next:(account)=>{
        console.log(account);
        this.router.navigate(['admin']);
      }
    })
  }
}
