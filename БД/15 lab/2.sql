create trigger Tr_Teacher_Dell
on Teacher  after Delete 
as declare @a1 char(10), @a2 varchar(100), @a3 char(10), @a4 char(20), @in varchar(300)
print 'Delete operation'
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('DEL','Tr_Teacher_ins',@in)
return
delete Teacher where Teacher='ÃÂÏ'
select * from Tr_Audit