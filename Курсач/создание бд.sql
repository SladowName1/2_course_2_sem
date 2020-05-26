go
create database Kursach
go
use Kursach
create table Admin
(Login nvarchar(50) primary key,
Password nvarchar(50)
)
create table Users
(Id int primary key identity(1,1),
Login nvarchar(50),
Password nvarchar(50)
)
create table Topic
(
NumberOfTopic int primary key identity(1,1),
Topic nvarchar(50),
Level int,
Image nvarchar(100),
Content nvarchar(1000)
)
create table AdminToUsers
(
AdminLogin nvarchar(50) references Admin(Login),
UsersId int references Users(Id),
UsersNumber int primary key identity(1,1)
)
create table UsersToTopic
(
UserId int references Users(Id),
TopicNumber int references Topic(NumberOfTopic),
Numbers int primary key identity (1,1)
)
insert Admin (Login,Password) values ('admin1','admin1')
