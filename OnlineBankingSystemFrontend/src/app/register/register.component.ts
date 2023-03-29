import { Component, OnInit} from '@angular/core';
import { Register } from '../models/register.model';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit{
  registerCustomerRequest:Register={
    UserName:'',
    Password:'',
    ConfirmPassword:'',
    MobileNo:'',
    AccountNo:'',
    Role:''
  };

  constructor(private registerservice:RegisterService,private router:Router){}

  ngOnInit():void{
  }

  registerUser(){
    console.log(this.registerCustomerRequest)
    this.registerservice.registerCustomer(this.registerCustomerRequest)
    .subscribe({
      next:(user)=>{
        if(user){
          this.router.navigate(['login']);
          // alert("Login SuccessFully");
        }
      },
      error: error => {
        alert("Please Enter Valid Details");
        console.log(error);
      }
    });
  }

}
