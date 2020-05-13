begin tran
insert Lab12 values (7123123,'asdasdsaf')
begin tran
update Lab12 set Ki=912314 where Ki=7123123
commit
if @@TRANCOUNT>0 rollback
select
(select count(*) from Lab12 where KI>100) '>100'