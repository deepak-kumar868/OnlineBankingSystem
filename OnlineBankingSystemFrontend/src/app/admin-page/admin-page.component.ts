import { Component } from '@angular/core';
import { Account } from '../models/account.model';
import { AccountDetailService } from '../services/account-detail.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent {
  CustomerDetails : any;
  userList : any;
  
  getSearchedInput = ()=>{
    const input =  (<HTMLInputElement>document.getElementById("searchInput"));
    this.findUserDetails(input.value);
  }
  findUserDetails = (input : any) =>{
       const newList = [];
       for (const detail of this.CustomerDetails) {
           if(detail.id == input || detail.name.match(input) != null){
            newList.push(detail);
            console.log(this.userList)
           }
       }
       this.userList = newList;
  }

  // constructor(){
  //   this.userList = [];
  //   this.CustomerDetails = [
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:1,
  //       name:"Adarsh Mishra",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:21,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:2,
  //       name:"Aman Mishra",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:22,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:3,
  //       name:"Aman Mishra",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:22,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:4,
  //       name:"Aman Mishra",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:21,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:5,
  //       name:"Abhay Mishra",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:22,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //     {
  //       imgSrc:'../../assets/Image/user.png',
  //       id:6,
  //       name:"Adarsh pandey",
  //       address:"Kundalahalli colony/ banglore /karnataka",
  //       age:21,
  //       dob:"22/03/1999",
  //       phone:9932232323,
  //       account:571000006382,
  //       transactionDetails:"click to know"
  //     },
  //   ]

  //}

  account:Account[]=[];
  constructor(private accountDetailService:AccountDetailService){
    // this.TransectionList = [];
    
  }

ngOnInit(): void {
  this.accountDetailService.getAllAccount()
  .subscribe({
    next:(account)=>{
      this.account=account;
      // console.log(account);
    },
    error:(response)=>{
      console.log(response);
    }
  });
}
}
