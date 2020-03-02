use GR_Univer
create table Faculty
(
Faculty char(10) not null
constraint PK_Faculty primary key(Faculty),
Faculty_name varchar(50) default '???',
)
Create table Profession
(
Profession char(20) not null 
constraint PK_Profession primary key(Profession),
Faculty char(10) not null
constraint FK_Profession_Faculty foreign key(Faculty)
references Faculty(Faculty),
Profession_name varchar(100) null,
Qualification varchar(50) null,
)
Create table Auditorium_type
(
Auditorium_type char(10) not null
constraint PK_Auditorium primary key(Auditorium_type),
Auditorium_typename varchar(30) null,
)
create table STUDENT 
(    IDSTUDENT   integer  identity(1000,1) constraint STUDENT_PK  primary key,
      IDGROUP   integer,        
      NAME   nvarchar(100), 
      BDAY   date,
      STAMP  timestamp,
      INFO     xml,
      FOTO     varbinary
) 

create table PROGRESS
 (  SUBJECT   char(10),                
     IDSTUDENT integer  constraint PROGRESS_IDSTUDENT_FK foreign key         
                      references STUDENT(IDSTUDENT),        
     PDATE    date, 
     NOTE     integer check (NOTE between 1 and 10)
  )
on G1
go
Create table Pulpit
(
Pulpit char(20) not null 
constraint PK_Pulpit primary key(Pulpit),
Pulpit_name varchar(100) null,
Faculty char(10) not null
constraint FK_Puplit_Facilty foreign key(Faculty)
references Faculty(Faculty),
)
Create table Subject
(
Subject char(10) not null
constraint PK_Subject primary key(Subject),
Subject_name varchar(100) null unique,
Pulpit char(20) not null
constraint FK_Subject_Puplit foreign key(Pulpit)
references Pulpit(Pulpit),
)

Create table Teacher 
(
Teacher char(10) not null
constraint PK_Teacher primary key(Teacher),
Teacher_name varchar(100) null,
Gender char(1),
Pulpit char(20) not null
constraint FK_Teacher_Pulpit foreign key(Pulpit)
references Pulpit(Pulpit),
)
Create table IDGroup
(
IDGroup int not null primary key,
Faculty char(10) not null references Faculty(Faculty),
Profession char(20) not null references Profession(Profession),
Year_first smallint  default 2018,
Course as YEAR(getdate())-Year_first,
)
on G2
go
Create table Auditorium
(
Auditorium char(20) not null primary key,
Auditorium_type char(10) not null
constraint FK_Auditorium_Auditorium_type foreign key(Auditorium_type)
references Auditorium_type(Auditorium_type),
Auditorium_capacity integer default 1,
Auditorium_name varchar(50) null,
)
Select * from Auditorium
Where Auditorium_capacity between 1 and 300