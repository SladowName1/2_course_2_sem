use master
create database Test
use Test
create table Test1
(
Test1 nvarchar(20) primary key,
Test1_name nvarchar(15),
Test1_number int identity(1,3),
)
create table Test2
(
Test2 nvarchar(20) primary key,
Test2_name nvarchar(15),
Test2_number int identity(11,1),
)
insert into Test1(Test1, Test1_name)
values('a','AA'),
('b','BB'),
('c','CC'),
('d','DD'),
('e','EE'),
('f','FF'),
('g','GG'),
('k','KK'),
('l','LL'),
('m','MM'),
('o','OO'),
('p','PP')
insert into Test2(Test2,Test2_name)
values('p','PP'),
('o','OO'),
('m','MM'),
('l','LL'),
('k','KK'),
('g','GG'),
('f','FF'),
('e','EE'),
('d','DD'),
('c','CC'),
('b','BB'),
('a','AA')
