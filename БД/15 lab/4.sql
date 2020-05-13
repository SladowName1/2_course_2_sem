create trigger Tr_teacher on Teacher after Insert, Delete, Update
as declare @a1 char(10), @a2 varchar(100), @a3 char(1), @a4 char(20),@in varchar(300)
declare @ins int =(select count(*) from inserted),
@del int =(select count(*) from deleted)
if @ins>0 and @del=0
begin print 'Insert'
set @a1=(select Teacher from Inserted)
set @a2=(select Teacher_name from inserted)
set @a3=(select Gender from inserted)
set @a4=(select Pulpit from inserted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('Ins','Tr_Teacher_ins',@in)
end 
else
if @ins=0 and @del<0
begin 
print 'Delete'
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('DEL','Tr_Teacher_ins',@in)
end
else
if @ins>0 and @del>0
begin
print 'Update'
set @a1=(select Teacher from Inserted)
set @a2=(select Teacher_name from inserted)
set @a3=(select Gender from inserted)
set @a4=(select Pulpit from inserted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('UPD','Tr_Teacher_ins',@in)
end
return 

insert into Teacher(Teacher,Teacher_name,Gender,Pulpit)
values ('ÏĞÀ','Ïéöâ Ğéöâéö Àôûâ','æ','ÈÑèÒ')
delete Teacher where Teacher='Ïğà'
insert into Teacher(Teacher,Teacher_name,Gender,Pulpit)
values ('ÏĞÀ','Ïéöâ Ğéöâéö Àôûâ','æ','ÈÑèÒ')
update Teacher set Teacher='ÀÏôûĞ' where Teacher='Ïğà'

select * from Tr_Audit
