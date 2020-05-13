declare @point varchar(32);
begin try
begin tran
delete Lab12 where Ki=16
set @point='p1' save tran @point
insert Lab12 values (12311,'fooh')
set @point='p2' save tran @point
insert Lab12 values (123,'1234')
commit tran
end try
begin catch
 print 'error'+case when
 error_number()=2627 and patindex('%PK_Lab12',error_message())>0
 then 'copy ki'
 else 'unnamed error'+cast(error_number() as varchar(5)) +error_message()
 end;
 if @@trancount>0
 begin 
 print 'control point:'+@point
 rollback tran @point;
 commit tran
 end
 end catch