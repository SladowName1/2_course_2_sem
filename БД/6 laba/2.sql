select Pulpit_name, Faculty.Faculty, Profession_name
from  Faculty inner join Pulpit 
on Pulpit.Faculty=Faculty.Faculty inner join Profession 
on Profession.Faculty=Pulpit.Faculty
where Pulpit_name in (select Pulpit_name from Pulpit Where (Pulpit_name Like '%технологи[ия]%'))