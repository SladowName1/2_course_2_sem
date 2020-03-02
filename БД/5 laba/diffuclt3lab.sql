create table Student
(
number int primary key identity (11,12343),
Name nvarchar(20) not null,
Second_name nvarchar(20) not null,
Birthday date not null,
Sex char(1) not null,
Date_of_post date not null,
)
insert into Student(Name, Second_name, Birthday, Sex, Date_of_post)
values('Alesya','Demedckevich','20-01-2000', 'w', '01-09-2018'),
('Pasha','Gru','20-01-2001', 'm', '01-09-2018'),
('Vanya','Den','20-01-2003', 'm', '01-09-2018'),
('Nastya','Novik','20-01-1999', 'w', '01-09-2018'),
('Polina','Tolst','20-01-1998', 'w', '01-09-2018'),
('Sanya','Yack','14-03-2000', 'm', '01-09-2018'),
('Filya','Dubr','13-11-2001', 'm', '01-09-2018'),
('Juliana','hats','16-11-2002', 'w', '01-09-2018')
select * from Student
where Sex='w' and DATEDIFF(year, Birthday, Date_of_post)>=18
