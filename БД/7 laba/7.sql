select g.Profession,
p.Subject,
avg(Note)Progress	
from IDGroup g,
PROGRESS p,
Faculty f
Where F.Faculty like '���'
Group by f.Faculty, p.SUBJECT, g.Profession
union
select g.Profession,
p.Subject,
avg(Note)Progress	
from IDGroup g,
PROGRESS p,
Faculty f
Where F.Faculty like '����'
Group by f.Faculty, p.SUBJECT, g.Profession



