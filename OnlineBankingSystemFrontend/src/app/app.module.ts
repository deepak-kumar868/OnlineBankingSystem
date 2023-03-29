import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BillpaymentComponent } from './billpayment/billpayment.component';
import { LoanComponent } from './loan/loan.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { AddAccountComponent } from './add-account/add-account.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CustomerComponent,
    HomeComponent,
    NavbarComponent,
    BillpaymentComponent,
    LoanComponent,
    AccountDetailsComponent,
    AdminPageComponent,
    UpdateAccountComponent,
    AddAccountComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  
 }
