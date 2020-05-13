--create table Tr_Audit
--( Id int identity,
--Stmt varchar(20) check (Stmt in ('INS', 'DEL', 'UPD')),
--TpName varchar(50),
--CC varchar(300)
--)
create trigger Tr_Teacher_ins
on Teacher after Insert
as declare @a1 char(10), @a2 varchar(100), @a3 char(1), @a4 char(20),@in varchar(300)
print 'Insert operation'
set @a1=(select Teacher from Inserted)
set @a2=(select Teacher_name from inserted)
set @a3=(select Gender from inserted)
set @a4=(select Pulpit from inserted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('Ins','Tr_Teacher_ins',@in)
return
insert into Teacher(Teacher,Teacher_name,Gender,Pulpit) 
values ('ГПВ','Грудинский Павел Владимирович','м','ИСиТ')
select * from Tr_Audit