use GR_Univer
select g.Profession,
p.Subject,
avg(Note)
from IDGroup g,
PROGRESS p,
Faculty f
Where F.Faculty like '���'
Group by CUBE(p.SUBJECT, g.Profession)
