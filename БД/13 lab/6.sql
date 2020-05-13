create procedure PAuditorium_inserttx
@a char(20), @n varchar(50), @c int=0, @t char(10)
as declare @rc int=1
begin try 
set transaction isolation level Serializable 
begin tran
insert into Auditorium_type(Auditorium_type)
values (@t)
exec @rc=PAuditorium_insert @a,@n,@c,@t
commit tran
return @rc
end try
begin catch 
print 'error number'+cast(error_number() as varchar(6))
print 'message'+error_message()
print 'level'+cast(error_severity() as varchar(6))
print 'mark'+cast(error_state() as varchar(8))
print 'number string'+ cast(error_line() as varchar(8))
if error_procedure() is not null
print 'procedure name'+error_procedure()
if @@trancount>0 rollback tran
return -1
end catch

declare @x int
exec @x=PAuditorium_inserttx @a='asdzxdcôûâz', @n='asôûâdzxdcz', @c=123, @t='asdzôûâxdcz'
print 'error code'+cast(@x as varchar(3))