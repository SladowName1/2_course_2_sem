--set transaction isolation level Read Committed
--begin transaction
--select count(*) from Lab12 where Ki=122
--select 'update Lab12' 'result', count(*) [Count]
--from Lab12 where Ki=122
--commit
--begin transaction
--update Lab12 set KI=1233
--where Ki=122
--rollback

set transaction isolation level read committed
begin tran
select count(*) from Lab12
begin tran 
delete Lab12 where Ki=123
select count(*) from Lab12
commit tran
select count(*) from Lab12
rollback tran
