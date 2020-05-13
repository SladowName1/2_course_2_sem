set transaction isolation level Serializable 
begin transaction
delete Lab12 Where Ki=71
insert Lab12 values (12341,'asdzxcasd')
update Lab12 set KI=12312 where KC='asdzxcasd'
select * from Lab12 where KC!='%fuck%'
commit
begin transaction
delete Lab12 where Ki=85
insert Lab12 values (123512321,'asdzxcq')
update Lab12 set Ki=85 where KC='asdzxcq'
select * from Lab12 where KC!='%fuck%'
commit
select * from Lab12 where KC!='%fuck%'