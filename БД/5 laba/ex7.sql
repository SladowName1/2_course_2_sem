select isnull(Teacher.Teacher_name,'***')[Teacher],isnull(Pulpit.Pulpit_name,'***')[Кафедра]
from Pulpit left outer join Teacher
on Teacher.Pulpit=Pulpit.Pulpit