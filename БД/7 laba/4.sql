use GR_Univer
select f.Faculty,
g.Profession,
g.Course,
round(avg(cast(p.Note as float(4))),2) as [Средняя оценкаа]
from IDGroup g inner join Faculty f
on g.Faculty=f.Faculty inner join STUDENT
on g.IDGroup=STUDENT.IDGROUP inner join PROGRESS p
on STUDENT.IDSTUDENT=p.IDSTUDENT
where p.SUBJECT like 'СУБД' or p.SUBJECT like 'ОАиП'
group by g.Profession,
g.Course,
f.Faculty