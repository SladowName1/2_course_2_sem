Create View [Pulpit counter]
as select f.Faculty_name,
count(*) [Pulpit counter]
from Faculty f join Pulpit p
on f.Faculty=p.Faculty
group by f.Faculty_name
