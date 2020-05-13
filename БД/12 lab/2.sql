begin try
begin tran 
delete Lab12 where Ki=12;
insert Lab12 values (1231,'asd');
insert Lab12 values (132,'asdzxc');
commit tran
end try
begin catch
print 'error' +case
when error_number()=2627 and patindex('%PK_Lab12',error_message())>0
then 'this error'
else 'unnamed error'+cast(error_number() as varchar (5))+error_message()
end
if @@trancount>0 rollback tran;
end catch;