select Pulpit_name, F.Faculty, Profession_name
from Faculty F,Pulpit P, Profession Pr
Where F.Faculty=P.Faculty and
Profession_name in (select Profession_name from Profession Where (Profession_name Like 'технологи[ия]%'))
select Pulpit_name, F.Faculty, Profession_name
from Faculty F,Pulpit P, Profession Pr
Where F.Faculty=P.Faculty and
Pulpit_name in (select Pulpit_name from Pulpit Where (Pulpit_name Like '%технологи[ия]%'))