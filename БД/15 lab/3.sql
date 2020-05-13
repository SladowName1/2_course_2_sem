create trigger Tr_Teacher_updd
on Teacher after Update
as declare @a1 char(10), @a2 varchar(100), @a3 char(1), @a4 char(20),@in varchar(300)
print 'Update operation'
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
insert into Tr_Audit(Stmt,TpName,CC) values('Upd','Tr_Teacher_ins',@in)
return
update Teacher set Teacher='цоб' where Teacher='цбо'
select * from Tr_Audit