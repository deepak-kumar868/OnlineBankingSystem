import { Component, OnInit} from '@angular/core';
import { Login } from '../models/login.model';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit{
  loginCustomerRequest:Login={
    UserName:'',
    Password:'',
    Role:''
  };

  constructor(private loginservice:LoginService,private router:Router){}

  ngOnInit():void{
  }

  loginUser(){
    console.log(this.loginCustomerRequest)
      this.loginservice.loginCustomer(this.loginCustomerRequest)    
    .subscribe({
      next:(user)=>{
        if(user){
          if(this.loginCustomerRequest.Role=="Customer"||this.loginCustomerRequest.Role=="customer"){
          this.router.navigate(['customer']);
          }
          else if(this.loginCustomerRequest.Role=="Admin"||this.loginCustomerRequest.Role=="admin"){
            this.router.navigate(['admin']);
          }
          else{
            window.alert("Please Enter valid details");
          }
        }
      },
      error: error => {
        window.alert("Invalid Credentials");
        console.log(error);
      }
    });
  }

}