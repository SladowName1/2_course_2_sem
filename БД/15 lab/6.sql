create trigger Tr_Teacher_Del1 on Teacher after Delete
as declare @a1 char(10), @a2 varchar(100), @a3 char(10), @a4 char(20), @in varchar(300)
print 'Delete operation'
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('DEL','Tr_Teacher_ins',@in)
return
go
create trigger Tr_Teacher_Del2 on Teacher after Delete
as declare @a1 char(10), @a2 varchar(100), @a3 char(10), @a4 char(20), @in varchar(300)
print 'Delete operation'
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('DEL','Tr_Teacher_ins',@in)
return
go
create trigger Tr_Teacher_Del3 on Teacher after Delete
as declare @a1 char(10), @a2 varchar(100), @a3 char(10), @a4 char(20), @in varchar(300)
print 'Delete operation'
set @a1=(select Teacher from deleted)
set @a2=(select Teacher_name from deleted)
set @a3=(select Gender from deleted)
set @a4=(select Pulpit from deleted)
set @in=@a1+' '+@a2+' '+@a3+' '+@a4
insert into Tr_Audit(Stmt,TpName,CC) values('DEL','Tr_Teacher_ins',@in)
return

exec  SP_SETTRIGGERORDER @triggername = 'Tr_Teacher_Del3',@order = 'First', @stmttype = 'DELETE';
exec sp_settriggerorder @triggername='Tr_Teacher_Del2', @order='Last', @stmttype='DELETE'

select t.name, e.type_desc
from sys.triggers t join sys.trigger_events e
on t.object_id=e.object_id
where OBJECT_NAME(t.parent_id)='Teacher' and e.type_desc='DELETE'