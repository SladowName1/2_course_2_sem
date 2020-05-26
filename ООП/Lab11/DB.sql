create database Lab11;
use Lab11;

create table Customers
(
NameCustomers nvarchar(50) primary key,
PhoneNumber int
)
create table Orders
(
IdOrders int primary key,
NameCustomers nvarchar(50) references Customers(NameCustomers),
Products nvarchar(50) references Products(NameProducts),
Photo nvarchar(50)
)
create table Products
(
Id int,
NameProducts nvarchar(50) primary key,
Price int,
Photo nvarchar(50)
)