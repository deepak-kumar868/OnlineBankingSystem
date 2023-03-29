import { Component, OnInit } from '@angular/core';
import { Account } from '../models/account.model';
@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent {
  TransectionList: any
  isVerified : any
  verifyOldPassword = ()=>{
    const passwrod = <HTMLInputElement>document.getElementById("OldPassword")
    //Type API code to verify old password
    if(passwrod.value == "AmanMishra"){
      this.isVerified = true;
      window.alert("Password verified successfully")
      passwrod.value = ""
    }
    else window.alert("please give valid password !")
  }
  verifyNewPassword = ()=>{
    const passwrod = <HTMLInputElement>document.getElementById("newPassword")
    //type one more condition in if() constraint
    //to validate password then
    //add new password into the base
    if(this.isVerified){
      this.isVerified = false;
      window.alert("Password changed successfully")
      passwrod.value = ""
    }
    else window.alert("Verify old password if not done yet or give valid password")
  }
  getCard = (data : any)=>{
    console.log("clicked")
      if(data == "1"){
        console.log("clicked!!")
         const card = <HTMLElement>document.getElementById("popUp_changePassword");
         card.classList.add("getCard")
      }
      else if(data == "2"){
         //popUp_accountSummary
         const card = <HTMLElement>document.getElementById("popUp_accountSummary");
         card.classList.add("getCard")
      }
      else {
        //popUp_recentTransaction
        const card = <HTMLElement>document.getElementById("popUp_recentTransaction");
        card.classList.add("getCard")
      }
  }
  removeCard = (data : any)=>{
    if(data == "1"){
      console.log("clicked!!")
       const card = <HTMLElement>document.getElementById("popUp_changePassword");
       card.classList.remove("getCard")
    }
    else if(data == "2"){
       //popUp_accountSummary
       const card = <HTMLElement>document.getElementById("popUp_accountSummary");
       card.classList.remove("getCard")
    }
    else {
      //popUp_recentTransaction
      const card = <HTMLElement>document.getElementById("popUp_recentTransaction");
      card.classList.remove("getCard")
    }
  }
  getTransectionList = ()=>{
       console.log("called")
      this.TransectionList = [
        {
         type:"credited",
         amount:23000,
         date:"02/04/2023"
        },
        {
          type:"credited",
          amount:23000,
          date:"02/04/2023"
         },
         {
          type:"debited",
          amount:23000,
          date:"02/04/2023"
         },
         {
          type:"debited",
          amount:23000,
          date:"02/04/2023"
         },
         {
          type:"credited",
          amount:23000,
          date:"02/04/2023"
         }
      ]
      console.log(this.TransectionList)
  }
}
