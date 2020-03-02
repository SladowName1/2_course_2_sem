select Faculty.Faculty, Faculty.Faculty_name, Pulpit.Pulpit, Profession.Profession, Student.name, Progress.Note,
case
when(Progress.Note=6) then 'six'
when(Progress.Note=7) then 'seven'
when(Progress.Note=8) then 'eight'
else ''
end as Notes
from Profession, Student, Progress, Faculty inner join Pulpit
on Faculty.Faculty=Pulpit.Faculty
where PROGRESS.NOTE between 6 and 8
Order by Faculty.Faculty asc, Faculty.Faculty_name asc, Pulpit.Pulpit asc, Profession.Profession asc, Progress.Note desc
