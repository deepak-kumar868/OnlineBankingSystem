create database OnlineBanking
use OnlineBanking


drop table Loan
drop table Transactions
drop table Accounts
drop table AccountType

create table Accounts
(Customer_ID int primary key,
Customer_Name varchar(15),
Customer_Address varchar(30),
Customer_Ph_No varchar(10),
Customer_Age int,
DOB datetime,Account_no varchar(15) unique,
IFSC varchar(20),
Account_Type_id int foreign key references AccountType(Account_Type_id),
Balance int,Branch varchar(20),CustomerType varchar(10));

insert into Accounts values
(1,'Deepak','Ranchi','6876656576',22,'12-08-2000','463846383476','HDFC',1,5678,'Mumbai','Admin'),
(2,'Yadav','Airoli','7776656576',23,'08-03-2002','163846309476','HDFC',2,99922,'Patna','Customer'),
(3,'Shreya','Patna','9876656576',20,'12-30-2002','969846383476','KVB',2,1234,'Delhi','Admin') ;

----- Account Type Table----------------
create table AccountType(Account_Type_id int primary key,
Account_Typ varchar(15),
Min_Balance float,
Interest int,Transaction_limit int);

insert into AccountType values
(1,'Saving',10000,5,100000),
(2,'Current',1000,3,50000);


select * from AccountType

-- Transaction table -------

create table Transactions
(Transaction_id int primary key,
Customer_id int foreign key references Accounts(Customer_ID),
Account_no varchar(15) foreign key references Accounts(Account_no),
Amount int, 
Date_of_Transaction datetime, Transaction_Status varchar(10));
--drop table Transactions;

insert into Transactions (Transaction_id,Customer_id, Account_no, Amount, Date_of_Transaction)
values (101,1,'463846383476',5678,'06-23-2033'),
(102,2,'969846383476',96789,'03-13-2022'),
(103,3,'163846309476',13678,'12-16-1999');

select * from Transactions;

--- Loan Table -----
create table Loan(Loan_id int primary key,
Customer_ID int foreign key references Accounts(Customer_ID),
Loan_Amount int,
Account_no varchar(15) foreign key references Accounts(Account_no),
Loan_Status varchar(15));

insert into Loan values
(111,1,200000,'463846383476','Open'),
(112,2,500000,'969846383476','Closed'),
(113,3,60000,'163846309476','Payed Off');


select * from AccountType;
select * from Accounts;
select * from Transactions;
select * from Loan;


-- drop table UserCredentials
create table UserCredentials(UserName varchar(50) primary key, Password varchar(50) not null,
MobileNo varchar(10),AccountNo varchar(15) unique,
Role varchar(50) not null,
);
insert into UserCredentials values('Shreya','Shreya','1234567890','35675787','Admin'),
('Kailash','Kailash','1234567890','4535675787','Customer')
select * from UserCredentials


