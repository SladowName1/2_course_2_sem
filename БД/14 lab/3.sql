create function FFacPul(@f varchar(20),@p char(20)) returns table
as return
select f.Faculty,p.Pulpit
from Faculty f left outer join Pulpit p
on f.Faculty=p.Faculty
where f.Faculty=isnull(@f,f.Faculty)
and p.Pulpit=isnull(@p,p.Pulpit)

select * from dbo.FFacPul(null,null)
select *from dbo.FFacPul('ррко',null)
select * from dbo.FFacPul(null,'кб')
select * from dbo.FFacPul('кут','рХо')