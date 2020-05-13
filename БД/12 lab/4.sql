set transaction isolation level Read Uncommitted
begin transaction
select @@Spid, 'insert Lab12' 'result', * from Lab12
where Kc='asd';
select @@spid, 'update Lab12' 'result', *from Lab12
Where Ki=null

begin transaction 
select @@spid
insert Lab12 values (2133, 'asd')
update Lab12 set Ki=1234 where Kc='asd'
select @@Spid, 'insert Lab12' 'result', * from Lab12

rollback