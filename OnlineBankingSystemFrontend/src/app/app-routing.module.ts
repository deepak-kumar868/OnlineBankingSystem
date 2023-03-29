import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { BillpaymentComponent } from './billpayment/billpayment.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { LoanComponent } from './loan/loan.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { AddAccountComponent } from './add-account/add-account.component';

const routes: Routes = [
  { path: 'login', component:LoginComponent },
  { path: 'register', component:RegisterComponent },
  { path: 'customer', component:CustomerComponent },
  { path: 'billpayment', component:BillpaymentComponent },
  { path: 'loan', component:LoanComponent },
  { path: '', component:HomeComponent },
  { path: 'account', component:AccountDetailsComponent },
  { path: 'admin', component:AdminPageComponent },
  {path:'admin/account/update/:id',component:UpdateAccountComponent},
  {path:'admin/account/add',component:AddAccountComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
