use GR_Univer
select g.Profession,
p.Subject,
avg(Note)  [Среднее]
from IDGroup g,
PROGRESS p,
Faculty f
Where F.Faculty like 'ТОВ'
Group by ROLLUP(p.SUBJECT, g.Profession)
