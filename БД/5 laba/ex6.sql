select isnull(Pulpit.Pulpit_name,'***')[�������],isnull(Teacher.Teacher_name,'***')[Teacher]
from Teacher right outer join Pulpit
on Teacher.Pulpit=Pulpit.Pulpit