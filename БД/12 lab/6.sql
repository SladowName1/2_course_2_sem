set transaction isolation level repeatable read
begin transaction
select * from Lab12 where KI=64
select case
when KI=64 then 'insert' else ''
end 'result', KI from Lab12 where KC like '%fuck%'
commit
begin transaction
insert Lab12 values (12343412,'12312')
commit