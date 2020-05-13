create procedure PAuditorium_insert
@a char(20), @n varchar(50), @c int=0, @t char(10)
as declare @rc int=1
begin try
insert Auditorium(Auditorium, Auditorium_type,Auditorium_capacity,Auditorium_name)
values (@a,@n,@c,@t)
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
return -1
end catch

declare @rb int
exec @rb=PAuditorium_insert @a='¡≈À√“”', @n=' ŒÃœ€', @c=123, @t='…÷¿…÷œ'
print 'error code'+cast(@rb as varchar(3))