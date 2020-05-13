Alter View [Pulpit counter] With Schemabinding
as select f.Faculty_name,
count(*) [Pulpit counter]
from dbo.Pulpit p join dbo.Faculty f
on p.Faculty=f.Faculty
group by f.Faculty_name